using System;

public class GameStateManager: IDisposable
{
    private readonly PlayerController _player;

    private readonly GamePlayOverlayScreen _overlay;
    private readonly DeathScreen _deathScreen;


    public GameStateManager(PlayerController player, GamePlayOverlayScreen overlay, DeathScreen deathScreen)
    {
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

    public void Dispose()
    {
        _player.OnDied -= HandlePlayerDied;
    }
}