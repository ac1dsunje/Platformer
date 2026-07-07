using System;
using System.Collections.Generic;
using _Game.Scripts.GamePlay.States;
using _Game.Scripts.Input;
using _Game.Scripts.Player;

namespace _Game.Scripts.GamePlay
{
public class GameStateManager : IDisposable
{
    private readonly PlayerStats _player;
    private readonly GeneralInputHandler _input;

    private readonly Dictionary<Type, GameFsmState> _states = new();
    private GameFsmState _fsmState;

    public GameStateManager(PlayerStats player, GeneralInputHandler input)
    {
        _input = input;
        _input.OnRestartClicked += RestartGameOnDeath;
        _input.OnPauseClicked += PauseGame;

        _player = player;
        _player.OnDied += HandlePlayerDied;
    }

    private void HandlePlayerDied()
    {
        ChangeState<GameFsmDeathState>();
    }

    private void RestartGameOnDeath()
    {
        if (IsInState<GameFsmDeathState>())
            RestartGame();
    }

    public void RestartGameOnButton()
    {
        RestartGame();
    }

    public void GoToMainMenu()
    {
        if (IsInState<GameFsmPauseState>())
        {
            ExitCurrentState();
            SceneLoader.SetMainMenuScene();
        }
    }

    private void PauseGame()
    {
        if (!IsInState<GameFsmPauseState>())
            ChangeState<GameFsmPauseState>();
    }

    public void ResumeGame()
    {
        ChangeState<GameFsmExploringState>();
    }

    private void RestartGame()
    {
        ExitCurrentState();
        SceneLoader.ReloadGamePlay();
    }


    public void AddState(GameFsmState fsmState)
    {
        _states.Add(fsmState.GetType(), fsmState);
    }

    public void ChangeState<T>() where T : GameFsmState
    {
        if (IsInState<T>()) return;

        var type = typeof(T);

        if (!_states.TryGetValue(type, out var state)) return;
        _fsmState?.Exit();
        _fsmState = state;
        _fsmState.Enter();
    }

    private bool IsInState<T>() where T : GameFsmState
    {
        return _fsmState?.GetType() == typeof(T);
    }

    private void ExitCurrentState()
    {
        _fsmState?.Exit();
    }

    public void Dispose()
    {
        _player.OnDied -= HandlePlayerDied;
        _input.OnRestartClicked -= RestartGameOnDeath;
        _input.OnPauseClicked -= PauseGame;
    }
}
}