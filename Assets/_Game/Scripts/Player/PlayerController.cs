using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerController : MonoBehaviour, IDamageAble, ICoinReceiver
{
    private CapsuleCollider2D _collider;
    private Rigidbody2D _rb;

    private IMovementInput _input;
    private PlayerStats _stats;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    public PlayerController Construct(IMovementInput input, PlayerStats stats)
    {
        _input = input;
        _stats = stats;

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
        return Physics2D.CapsuleCast(transform.position, _collider.size, _collider.direction, 0, Vector2.down, 0.15f);
    }

    private void Jump()
    {
        if (!GetIsOnGround()) return;
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _stats.JumpForce);
    }

    private void Move(float velocity)
    {
        _rb.linearVelocity = new(velocity * _stats.MoveSpeed, _rb.linearVelocity.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            _stats.TakeDamage(_stats.MaxHealth);
        }
    }

    public void TakeDamage(int amount) => _stats.TakeDamage(amount);

    public void AddCoins(int value) => _stats.AddCoins(value);
}