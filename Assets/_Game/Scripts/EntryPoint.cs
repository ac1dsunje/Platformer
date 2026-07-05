using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private InputHandler _input;

    [Header("Level")]
    [SerializeField] private GameObject _levelPrefab;

    private LevelController _levelController;
    private PlayerPresenter _playerPresenter;

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
        PlayerModel model = new(_playerConfig.HealthConfig, _playerConfig.MovementConfig);

        _playerPresenter = new(model, _input);

        PlayerView view = Instantiate(_playerConfig.Prefab, _levelController.GetSpawnPosition.position, Quaternion.identity)
            .GetComponent<PlayerView>().Construct(_playerPresenter, model);

    }

    private void OnDisable()
    {
        _playerPresenter.Dispose();
    }
}