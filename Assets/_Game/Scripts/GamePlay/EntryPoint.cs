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
    [SerializeField] private int _levelIndex = 1;
    [SerializeField] private GameObject[] _levelPrefabs;

    [Header("UI")]
    [SerializeField] private GamePlayOverlayScreen _overlayScreen;
    [SerializeField] private DeathScreen _deathScreen;
    [SerializeField] private PauseScreen _pauseScreen;

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
        return Instantiate(_levelPrefabs[_levelIndex]).GetComponent<LevelController>();
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
        _overlayScreen.Construct(_levelController, _playerModel);
        _pauseScreen.Construct(_gameStateManager);
        return new(_overlayScreen, _deathScreen, _pauseScreen);
    }

    private void OnDestroy()
    {
        _gameStateManager?.Dispose();
    }
}
}