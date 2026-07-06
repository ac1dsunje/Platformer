using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;

    [Header("Input")]
    [SerializeField] private GeneralInputHandler _input;
    [SerializeField] private StandardMovementInput _movementInput;

    [Header("Camera")]
    [SerializeField] private CameraController _camera;
    [SerializeField] private float _speedFollow;

    [Header("Level")]
    [SerializeField] private GameObject _levelPrefab;

    [Header("UI")]
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _overlayScreenPrefab;
    [SerializeField] private GameObject _deathScreenPrefab;
    [SerializeField] private GameObject _pauseScreenPrefab;

    private LevelController _levelController;
    private PlayerController _playerView;
    private PlayerStats _playerModel;
    private GameStateManager _gameStateManager;

    private void Awake()
    {
        _levelController = SpawnLevel();
        SpawnPlayer();

        _gameStateManager = new(_playerModel, _input);

        RegisterStates();

        _camera.Construct(_playerView.transform, _speedFollow);
    }

    private LevelController SpawnLevel()
    {
        return Instantiate(_levelPrefab).GetComponent<LevelController>();
    }

    private void SpawnPlayer()
    {
        _playerModel = new(_playerConfig.HealthConfig, _playerConfig.MovementConfig);
        _playerView = Instantiate(_playerConfig.Prefab, _levelController.GetSpawnPosition.position, Quaternion.identity)
            .GetComponent<PlayerController>().Construct(_movementInput, _playerModel);
    }

    private void RegisterStates()
    {
        var ui = CreateUIManager();

        _gameStateManager.AddState(new ExploringState(ui));
        _gameStateManager.AddState(new DeathState(ui));
        _gameStateManager.AddState(new PauseState(ui));
        _gameStateManager.ChangeState<ExploringState>();
    }

    private UIManager CreateUIManager()
    {
        var overlay = Instantiate(_overlayScreenPrefab, _canvas.transform, false).GetComponent<GamePlayOverlayScreen>();
        overlay.Initialize(_levelController, _playerView);

        var deathScreen = Instantiate(_deathScreenPrefab, _canvas.transform, false).GetComponent<DeathScreen>();

        var pauseScreen = Instantiate(_pauseScreenPrefab, _canvas.transform, false)
            .GetComponent<PauseScreen>().Initialize(_gameStateManager);

        return new(overlay, deathScreen, pauseScreen);
    }

    private void OnDestroy()
    {
        _gameStateManager?.Dispose();
    }
}