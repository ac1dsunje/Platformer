using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    private PlayerConfig _config;
    private Rigidbody2D _rb;

    private float _horizontal;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(PlayerConfig config)
    {
        _config = config;
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        _sprite.sprite = _config.Sprite;
    }

    private void FixedUpdate()
    {
        Vector2 movement = new(_horizontal * _config.MovementSpeed, _rb.linearVelocity.y);


        _rb.linearVelocity = movement;
    }
}
