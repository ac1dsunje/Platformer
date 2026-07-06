using System;

public class GameStateManager: IDisposable
{
    private readonly PlayerController _player;
    private readonly GeneralInputHandler _input;

    private readonly ExploringState _exploringState;
    private readonly DeathState _deathState;
    private GameState _state;

    public GameStateManager(PlayerController player, GeneralInputHandler input, ExploringState exploring, DeathState death)
    {
        _input = input;
        _input.OnRestartClicked += RestartGame;

        _player = player;
        _player.OnDied += HandlePlayerDied;

        _exploringState = exploring;
        _deathState = death;

        ChangeState(_exploringState);
    }

    private void HandlePlayerDied()
    {
        ChangeState(_deathState);
    }

    private void ChangeState(GameState newState)
    {
        _state?.Exit();

        _state = newState;
        _state.Enter();
    }

    private void RestartGame()
    {
        SceneLoader.ReloadGamePlay();
    }

    public void Dispose()
    {
        _player.OnDied -= HandlePlayerDied;
        _input.OnRestartClicked -= RestartGame;
    }
}