using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private StandardMovementInput _input;

    [Header("Level")]
    [SerializeField] private GameObject _levelPrefab;

    private LevelController _levelController;
    private PlayerController _player;

    private void Awake()
    {
        SpawnLevel();
        SpawnPlayer();
    }

    private void SpawnLevel()
    {
        _levelController = Instantiate(_levelPrefab).GetComponent<LevelController>();
    }

    private void SpawnPlayer()
    {
        _player = Instantiate(_playerConfig.Prefab, _levelController.GetSpawnPosition.position, Quaternion.identity)
            .GetComponent<PlayerController>().Construct(_input, _playerConfig.HealthConfig, _playerConfig.MovementConfig);
    }
}