using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D _collider;
    private IMovementInput _input;
    private Rigidbody2D _rb;
    private PlayerStats _stats;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

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
            _stats.TakeDamage(9999);
        }
    }
}