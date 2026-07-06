using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GateController _enterGate;
    [SerializeField] private GateController _exitGate;
    [SerializeField] private Light2D _light;
    public Transform GetSpawnPosition => _spawnPosition;

    public int TimeSec { get; private set; }

    private void Awake()
    {
        _enterGate?.Open();
        _exitGate?.Close();
    }

    private void Update()
    {
        TimeSec = (int)Time.time;
    }
}
