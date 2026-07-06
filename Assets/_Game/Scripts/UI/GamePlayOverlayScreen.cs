using System;
using TMPro;
using UnityEngine;

public class GamePlayOverlayScreen: ScreenManager
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private LevelController _level;
    private bool _isInited;

    public void Initialize(LevelController level)
    {
        _level = level;
        _isInited = true;
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