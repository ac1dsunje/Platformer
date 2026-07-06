using System;
using System.Collections.Generic;

public class GameStateManager : IDisposable
{
    private readonly PlayerController _player;
    private readonly GeneralInputHandler _input;

    private readonly Dictionary<Type, GameState> _states = new();
    private GameState _state;

    public GameStateManager(PlayerController player, GeneralInputHandler input)
    {
        _input = input;
        _input.OnRestartClicked += RestartGameOnDeath;
        _input.OnPauseClicked += PauseGame;

        _player = player;
        _player.OnDied += HandlePlayerDied;
    }

    private void HandlePlayerDied()
    {
        ChangeState<DeathState>();
    }

    private void RestartGameOnDeath()
    {
        if (IsInState<DeathState>())
            RestartGame();
    }

    public void RestartGameOnButton()
    {
        RestartGame();
    }

    public void GoToMainMenu()
    {
        if (IsInState<PauseState>())
        {
            ExitCurrentState();
            SceneLoader.SetMainMenuScene();
        }
    }

    private void PauseGame()
    {
        if (!IsInState<PauseState>())
            ChangeState<PauseState>();
    }

    public void ResumeGame()
    {
        ChangeState<ExploringState>();
    }

    private void RestartGame()
    {
        ExitCurrentState();
        SceneLoader.ReloadGamePlay();
    }


    public void AddState(GameState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void ChangeState<T>() where T : GameState
    {
        if (IsInState<T>()) return;

        var type = typeof(T);

        if (_states.TryGetValue(type, out var state))
        {
            _state?.Exit();
            _state = state;
            _state.Enter();
        }
    }

    protected bool IsInState<T>() where T : GameState
    {
        return _state?.GetType() == typeof(T);
    }

    protected void ExitCurrentState()
    {
        _state?.Exit();
    }

    public void Dispose()
    {
        _player.OnDied -= HandlePlayerDied;
        _input.OnRestartClicked -= RestartGameOnDeath;
        _input.OnPauseClicked -= PauseGame;
    }
}