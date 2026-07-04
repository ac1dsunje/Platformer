using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private PlayerConfig _config;
    private Rigidbody2D _rb;

    private float _horizontal;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public PlayerController Initialize(PlayerConfig config)
    {
        _config = config;

        return this;
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector2 movement = new(_horizontal * _config.MovementSpeed, _rb.linearVelocity.y);

        _rb.linearVelocity = movement;
    }
}
