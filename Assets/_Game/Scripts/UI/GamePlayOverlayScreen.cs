using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayOverlayScreen: ScreenManager
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private RectTransform _healthContainer;
    [SerializeField] private GameObject _healthSlotPrefab;
    [SerializeField] private TextMeshProUGUI _coinsCollectedText;

    private LevelController _level;
    private PlayerStats _player;

    private List<HealthSlotUI> _healthSlots = new();

    private bool _isInited;

    public void Construct(LevelController level, PlayerStats player)
    {
        _level = level;
        _player = player;

        _player.OnTakeHit += UpdateHealthBar;
        _player.OnCoinAdded += UpdateCoinsCount;

        SetHealthBar();

        _isInited = true;
    }

    private void SetHealthBar()
    {
        for(int i = 0; i<_player.MaxHealth; i++)
        {
            var slot = Instantiate(_healthSlotPrefab, _healthContainer, false).GetComponent<HealthSlotUI>();
            slot.Set();
            _healthSlots.Add(slot);
        }
    }

    private void UpdateHealthBar(int health, int maxHealth)
    {
        for(int i = 0; i< maxHealth; i++)
        {
            if(i < health)
                _healthSlots[i].Set();
            else
                _healthSlots[i].UnSet();
        }
    }

    private void UpdateCoinsCount(int amount)
    {
        _coinsCollectedText.text = amount.ToString();
    }

    private void WriteTime(int sec)
    {
        var seconds = sec % 60f;
        var minutes = Mathf.Floor(sec / 60f);

        _timerText.text = String.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void Update()
    {
        if (!_isInited) return;

        WriteTime(_level.TimeSec);
    }

    private void OnDestroy()
    {
        _player.OnTakeHit -= UpdateHealthBar;
        _player.OnCoinAdded -= UpdateCoinsCount;
    }
}