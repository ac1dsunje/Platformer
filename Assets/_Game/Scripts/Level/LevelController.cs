using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GateController _enterGate;
    [SerializeField] private GateController _exitGate;
    public Transform GetSpawnPosition => _spawnPosition;

    private void Awake()
    {
        _enterGate?.Open();
        _exitGate?.Close();
    }
}
