using System;

namespace _Game.Scripts.Input
{
public interface IMovementInput
{
    event Action<float> OnHorizontalInput;
    event Action OnJumpRequested;
}
}