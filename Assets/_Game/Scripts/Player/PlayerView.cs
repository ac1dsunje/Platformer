using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerView: MonoBehaviour
{
    [SerializeField] private GroundChecker _groundCheck;

    private PlayerModel _model;
    private Rigidbody2D _rb;

    private float _horizontal;
    private bool _jumpRequested;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public PlayerView Initialize(PlayerModel model)
    {
        _model = model;

        return this;
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (_groundCheck.IsOnGround && Input.GetKeyDown(KeyCode.Space))
        {
                _jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new(_horizontal * _model.MoveSpeed, _rb.linearVelocity.y);
        if (_jumpRequested)
        {
            _rb.linearVelocity = Vector2.up * _model.JumpForce;
            _jumpRequested = false;
        }
    }
}
