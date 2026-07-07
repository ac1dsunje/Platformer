using UnityEngine;

public class CoinController: MonoBehaviour
{
    [SerializeField] private CoinConfig _config;

    private float _rotationSpeed;

    private void Awake()
    {
        _rotationSpeed = Random.Range(_config.RotationSpeedMin, _config.RotationSpeedMax);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collect(collision);
    }

    private void Collect(Collider2D collider)
    {
        if (collider.TryGetComponent<ICoinReceiver>(out var coinReceiver))
        {
            coinReceiver.AddCoins(_config.Value);
            Destroy(gameObject);
        }
    }
}