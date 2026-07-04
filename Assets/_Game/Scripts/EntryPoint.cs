using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;

    [Header("Level")]
    [SerializeField] private GameObject _levelPrefab;

    private PlayerController _playerController;
    private LevelController _levelController;

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
        _playerController = Instantiate(_playerConfig.Prefab, _levelController.GetSpawnPosition.position, Quaternion.identity)
            .GetComponent<PlayerController>().Initialize(_playerConfig);
    }
}