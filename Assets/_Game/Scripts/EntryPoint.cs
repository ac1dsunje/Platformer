using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;

    [Header("Level")]
    [SerializeField] private GameObject _levelPrefab;

    private PlayerController _playerController;

    private void Awake()
    {
        Instantiate(_levelPrefab);
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _playerController = Instantiate(_playerConfig.Prefab, _playerConfig.SpawnPosition, Quaternion.identity).GetComponent<PlayerController>();
        _playerController.Initialize(_playerConfig);
    }
}