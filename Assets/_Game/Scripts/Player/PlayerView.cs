using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerView: MonoBehaviour
{
    [SerializeField] private GroundChecker _groundCheck;
    private Rigidbody2D _rb;

    private PlayerPresenter _presenter;
    private PlayerModel _model;


    public PlayerView Construct(PlayerPresenter presenter, PlayerModel model)
    {
        _presenter = presenter;
        _model = model;

        _model.OnJumpRequested += Jump;
        _model.OnMovement += Move;

        _groundCheck.OnGroundChanged += SetGroundState;

        return this;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        _groundCheck.OnGroundChanged -= SetGroundState;
        _model.OnJumpRequested -= Jump;
        _model.OnMovement -= Move;
    }

    private void SetGroundState(bool state) => _presenter.SetGroundState(state);

    private void Jump(float jumpForce)
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
    }

    private void Move(float velocity)
    {
        _rb.linearVelocity = new(velocity, _rb.linearVelocity.y);
    }
}
