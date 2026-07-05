using System;

public class PlayerModel
{
    private float _maxHealth;
    private float _health;

    private float _moveSpeed;
    private float _jumpForce;

    private float _velocity;

    private bool _isOnGround;

    public event Action<float> OnJumpRequested;
    public event Action<float> OnMovement;

    public PlayerModel(HealthConfig healthConfig, MovementConfig movementConfig)
    {

        _maxHealth = healthConfig.MaxHealth;
        _health = healthConfig.MaxHealth;

        _moveSpeed = movementConfig.MovementSpeed;
        _jumpForce = movementConfig.JumpForce;
    }

    public void SetOnGroundState(bool state) => _isOnGround = state;

    public void RequestJump()
    {
        if (!_isOnGround) return;

        OnJumpRequested?.Invoke(_jumpForce);
    }

    public void SetVelocity(float value)
    {
        _velocity = value * _moveSpeed;
        OnMovement?.Invoke(_velocity);
    }
}