using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayOverlayScreen: ScreenManager
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private RectTransform _healthContainer;
    [SerializeField] private GameObject _healthSlotPrefab;

    private LevelController _level;
    private PlayerController _player;

    private List<HealthSlotUI> _healthSlots = new();

    private bool _isInited;

    public void Initialize(LevelController level, PlayerController player)
    {
        _level = level;
        _player = player;

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

    private void Update()
    {
        if (!_isInited) return;

        WriteTime(_level.TimeSec);
    }

    private void WriteTime(int sec)
    {
        var seconds = sec % 60f;
        var minutes = Mathf.Floor(sec / 60f);

        _timerText.text = String.Format("{0:00}:{1:00}", minutes, seconds);
    }
}