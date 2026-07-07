using _Game.Scripts.Player.Interfaces;
using UnityEngine;

namespace _Game.Scripts.Level.Collectibles.Coins
{
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

    private void Collect(Collider2D other)
    {
        if (!other.TryGetComponent<ICoinReceiver>(out var coinReceiver)) return;
        coinReceiver.AddCoins(_config.Value);
        Destroy(gameObject);
    }
}
}