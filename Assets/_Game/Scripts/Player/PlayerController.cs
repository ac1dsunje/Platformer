using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour, IDamageAble, ICoinReceiver
{
    [SerializeField] private AnimationClip _deathAnim;
    [SerializeField] private AnimationClip _runningAnim;
    [SerializeField] private AnimationClip _idleAnim;

    private CapsuleCollider2D _collider;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private IMovementInput _input;
    private PlayerStats _stats;

    private PlayerState _state;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public PlayerController Construct(IMovementInput input, PlayerStats stats)
    {
        _input = input;
        _stats = stats;

        _stats.OnDied += HandleDeath;

        _input.OnJumpRequested += Jump;
        _input.OnHorizontalInput += Move;

        return this;
    }

    private void OnDestroy()
    {
        _input.OnJumpRequested -= Jump;
        _input.OnHorizontalInput -= Move;

        _stats.OnDied -= HandleDeath;
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

        if (velocity < 0)
        {
            _sprite.flipX = true;
        }
        else if (velocity > 0)
        {
            _sprite.flipX = false;
        }
    }

    private void HandleDeath()
    {
        _animator.Play(_deathAnim.name);
    }

    public void TakeDamage(int amount) => _stats.TakeDamage(amount);

    public void AddCoins(int value) => _stats.AddCoins(value);
}