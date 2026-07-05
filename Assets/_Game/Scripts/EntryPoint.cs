using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private StandardMovementInput _input;

    [Header("Camera")]
    [SerializeField] private CameraController _camera;
    [SerializeField] private float _speedFollow;

    [Header("Level")]
    [SerializeField] private GameObject _levelPrefab;

    [Header("UI")]
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _overlayScreenPrefab;
    [SerializeField] private GameObject _deathScreenPrefab;

    private LevelController _levelController;
    private PlayerController _player;
    private GameStateManager _gameStateManager;

    private void Awake()
    {
        _levelController = SpawnLevel();
        _player = SpawnPlayer();

        GamePlayOverlayScreen overlay = Instantiate(_overlayScreenPrefab, _canvas.transform, false).GetComponent<GamePlayOverlayScreen>();
        DeathScreen deathScreen = Instantiate(_deathScreenPrefab, _canvas.transform, false).GetComponent<DeathScreen>();

        _gameStateManager = new(_player, overlay, deathScreen);

        _camera.Construct(_player.transform, _speedFollow);
    }

    private LevelController SpawnLevel()
    {
        return Instantiate(_levelPrefab).GetComponent<LevelController>();
    }

    private PlayerController SpawnPlayer()
    {
        return Instantiate(_playerConfig.Prefab, _levelController.GetSpawnPosition.position, Quaternion.identity)
            .GetComponent<PlayerController>().Construct(_input, _playerConfig.HealthConfig, _playerConfig.MovementConfig);
    }

    private void OnDisable()
    {
        _gameStateManager.Dispose();
    }
}