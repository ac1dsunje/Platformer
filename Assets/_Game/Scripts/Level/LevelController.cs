using _Game.Scripts.Level.Gate;
using _Game.Scripts.Player.Interfaces;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Game.Scripts.Level
{
public class LevelController : MonoBehaviour
{
    [Header("Spawn & Gates")]
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GateController _enterGate;
    [SerializeField] private GateController _exitGate;

    [Header("Day/Night Cycle")]
    [SerializeField] private Light2D _light;
    [SerializeField, Min(1f)] private float _dayDurationSeconds = 120f;
    [SerializeField] private float _minIntensity = 0.1f;
    [SerializeField] private float _maxIntensity = 1f;

    public Transform GetSpawnPosition => _spawnPosition;

    private float _time;
    public int TimeSec => (int)_time;

    private void Awake()
    {
        _enterGate?.Open();
        _exitGate?.Close();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        UpdateLightIntensity();
    }

    private void UpdateLightIntensity()
    {
        var t = (_time % _dayDurationSeconds) / _dayDurationSeconds;
        var sineValue = (Mathf.Sin(t * Mathf.PI * 2f) + 1f) / 2f;
        _light.intensity = Mathf.Lerp(_minIntensity, _maxIntensity, sineValue);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageAble>(out var damageable))
        {
            damageable.TakeDamage(999);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
}