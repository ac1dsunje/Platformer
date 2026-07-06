using System;
using System.Collections.Generic;

public class GameStateManager: IDisposable
{
    private readonly PlayerController _player;
    private readonly GeneralInputHandler _input;

    private Dictionary<Type, GameState> _states = new();

    private GameState _state;

    public GameStateManager(PlayerController player, GeneralInputHandler input)
    {
        _input = input;
        _input.OnRestartClicked += RestartGame;

        _player = player;
        _player.OnDied += HandlePlayerDied;
    }

    public void AddState(GameState state)
    {
        _states.Add(state.GetType(), state);
    }

    private void HandlePlayerDied()
    {
        ChangeState<DeathState>();
    }

    public void ChangeState<T>() where T: GameState
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

    private bool IsInState<T>() where T : GameState
    {
        return _state?.GetType() == typeof(T);
    }

    private void RestartGame()
    {
        if(IsInState<DeathState>())
            SceneLoader.ReloadGamePlay();
    }

    public void Dispose()
    {
        _player.OnDied -= HandlePlayerDied;
        _input.OnRestartClicked -= RestartGame;
    }
}