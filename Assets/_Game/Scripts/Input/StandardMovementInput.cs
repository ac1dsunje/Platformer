using System;
using UnityEngine;

namespace _Game.Scripts.Input
{
public class StandardMovementInput: MonoBehaviour, IMovementInput
{
    public event Action<float> OnHorizontalInput;
    public event Action OnJumpRequested;

    private void Update()
    {
        OnHorizontalInput?.Invoke(UnityEngine.Input.GetAxis("Horizontal"));

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpRequested?.Invoke();
        }
    }
}
}