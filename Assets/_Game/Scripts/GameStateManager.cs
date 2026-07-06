using System;

public class GameStateManager: IDisposable
{
    private readonly PlayerController _player;

    private readonly GamePlayOverlayScreen _overlay;
    private readonly DeathScreen _deathScreen;
    private readonly GeneralInputHandler _input;


    public GameStateManager(PlayerController player, GamePlayOverlayScreen overlay, DeathScreen deathScreen, GeneralInputHandler input)
    {
        _input = input;
        _input.OnRestartClicked += RestartGame;

        _player = player;
        _player.OnDied += HandlePlayerDied;

        _overlay = overlay;
        _deathScreen = deathScreen;

        _overlay.Show();
        _deathScreen.Hide();
    }

    private void HandlePlayerDied()
    {
        _overlay.Hide();
        _deathScreen.Show();
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