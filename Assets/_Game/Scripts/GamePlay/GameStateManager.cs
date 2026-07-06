using System;

public class GameStateManager : StateManager<GameState>, IDisposable
{
    private readonly PlayerController _player;
    private readonly GeneralInputHandler _input;

    public GameStateManager(PlayerController player, GeneralInputHandler input)
    {
        _input = input;
        _input.OnRestartClicked += RestartGame;

        _player = player;
        _player.OnDied += HandlePlayerDied;
    }

    private void HandlePlayerDied()
    {
        ChangeState<DeathState>();
    }

    private void RestartGame()
    {
        if (IsInState<DeathState>())
            SceneLoader.ReloadGamePlay();
    }

    public void Dispose()
    {
        _player.OnDied -= HandlePlayerDied;
        _input.OnRestartClicked -= RestartGame;
    }
}