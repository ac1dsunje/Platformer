using System;
using UnityEngine;

public class GeneralInputHandler: MonoBehaviour
{
    public event Action OnRestartClicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnRestartClicked?.Invoke();
        }
    }
}