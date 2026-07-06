using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private IMovementInput _input;
    private Rigidbody2D _rb;

    public float MaxHealth { get; private set; }
    private float _health;

    private float _moveSpeed;
    private float _jumpForce;

    private float _velocity;
    private bool _isOnGround;

    public event Action OnDied;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public PlayerController Construct(IMovementInput input, HealthConfig healthConfig, MovementConfig movementConfig)
    {
        _input = input;

        MaxHealth = healthConfig.MaxHealth;
        _health = healthConfig.MaxHealth;

        _moveSpeed = movementConfig.MovementSpeed;
        _jumpForce = movementConfig.JumpForce;

        _input.OnJumpRequested += Jump;
        _input.OnHorizontalInput += Move;

        return this;
    }

    private void OnDestroy()
    {

        _input.OnJumpRequested -= Jump;
        _input.OnHorizontalInput -= Move;
    }

    private bool GetIsOnGround()
    {
        _isOnGround = Physics2D.CapsuleCast(transform.position, new Vector2(.9f, .9f), CapsuleDirection2D.Vertical, 0, Vector2.down, 0.15f);
        return _isOnGround;
    }

    private void Jump()
    {
        if (!GetIsOnGround()) return;
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
    }

    private void Move(float velocity)
    {
        _velocity = velocity * _moveSpeed;
        _rb.linearVelocity = new(_velocity, _rb.linearVelocity.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            OnDied?.Invoke();
        }
    }
}