using System;

public interface IMovementInput
{
    event Action<float> OnHorizontalInput;
    event Action OnJumpRequested;
}