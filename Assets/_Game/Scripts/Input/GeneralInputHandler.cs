using System;
using UnityEngine;

namespace _Game.Scripts.Input
{
public class GeneralInputHandler: MonoBehaviour
{
    public event Action OnRestartClicked;
    public event Action OnPauseClicked;

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            OnRestartClicked?.Invoke();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseClicked?.Invoke();
        }
    }
}
}