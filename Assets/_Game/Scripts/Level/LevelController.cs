using UnityEngine;
using UnityEngine.Rendering.Universal;

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
        float t = (_time % _dayDurationSeconds) / _dayDurationSeconds;
        float sineValue = (Mathf.Sin(t * Mathf.PI * 2f) + 1f) / 2f;
        _light.intensity = Mathf.Lerp(_minIntensity, _maxIntensity, sineValue);
    }
}