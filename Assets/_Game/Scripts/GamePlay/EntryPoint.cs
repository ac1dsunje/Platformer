using _Game.Scripts.GamePlay.States;
using _Game.Scripts.Input;
using _Game.Scripts.Level;
using _Game.Scripts.Player;
using _Game.Scripts.Player.configs;
using _Game.Scripts.UI;
using Cinemachine;
using UnityEngine;

namespace _Game.Scripts.GamePlay
{
public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;

    [Header("Input")]
    [SerializeField] private GeneralInputHandler _input;
    [SerializeField] private StandardMovementInput _movementInput;

    [Header("Camera")]
    [SerializeField] private CinemachineVirtualCamera _camera;
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

        _camera.Follow = _playerView.transform;
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

        _gameStateManager.AddState(new GameFsmExploringState(ui));
        _gameStateManager.AddState(new GameFsmDeathState(ui));
        _gameStateManager.AddState(new GameFsmPauseState(ui));
        _gameStateManager.ChangeState<GameFsmExploringState>();
    }

    private UIManager CreateUIManager()
    {
        var overlay = Instantiate(_overlayScreenPrefab, _canvas.transform, false).GetComponent<GamePlayOverlayScreen>();
        overlay.Construct(_levelController, _playerModel);

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
}