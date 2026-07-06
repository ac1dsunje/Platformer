using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GateController _enterGate;
    [SerializeField] private GateController _exitGate;
    [SerializeField] private Light2D _light;
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
    }
}
