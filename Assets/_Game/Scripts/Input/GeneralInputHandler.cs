using System;
using UnityEngine;

public class GeneralInputHandler: MonoBehaviour
{
    public event Action OnRestartClicked;
    public event Action OnPauseClicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnRestartClicked?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseClicked?.Invoke();
        }
    }
}