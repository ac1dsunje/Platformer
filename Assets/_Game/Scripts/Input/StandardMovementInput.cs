using System;
using UnityEngine;

public class StandardMovementInput: MonoBehaviour, IMovementInput
{
    public event Action<float> OnHorizontalInput;
    public event Action OnJumpRequested;

    private void Update()
    {
        OnHorizontalInput?.Invoke(Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpRequested?.Invoke();
        }
    }
}