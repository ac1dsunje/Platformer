using System;

public class GameStateManager : StateManager<GameState>, IDisposable
{
    private readonly PlayerController _player;
    private readonly GeneralInputHandler _input;

    public GameStateManager(PlayerController player, GeneralInputHandler input)
    {
        _input = input;
        _input.OnRestartClicked += RestartGame;
        _input.OnPauseClicked += PauseGame;

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

    private void PauseGame()
    {
        if (!IsInState<PauseState>())
            ChangeState<PauseState>();
    }

    public void ResumeGame()
    {
        ChangeState<ExploringState>();
    }

    public void Dispose()
    {
        _player.OnDied -= HandlePlayerDied;
        _input.OnRestartClicked -= RestartGame;
        _input.OnPauseClicked -= PauseGame;
    }
}