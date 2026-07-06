using System;

public class GameStateManager : StateManager<GameState>, IDisposable
{
    private readonly PlayerController _player;
    private readonly GeneralInputHandler _input;

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

    public void Dispose()
    {
        _player.OnDied -= HandlePlayerDied;
        _input.OnRestartClicked -= RestartGameOnDeath;
        _input.OnPauseClicked -= PauseGame;
    }
}