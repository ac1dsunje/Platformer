public class UIManager
{
    private readonly GamePlayOverlayScreen _overlay;
    private readonly DeathScreen _deathScreen;
    private readonly PauseScreen _pauseScreen;

    public UIManager(GamePlayOverlayScreen overlay, DeathScreen deathScreen, PauseScreen pauseScreen)
    {
        _overlay = overlay;
        _deathScreen = deathScreen;
        _pauseScreen = pauseScreen;
    }

    public void SetExploringScreens()
    {
        _deathScreen.Hide();
        _pauseScreen.Hide();
        _overlay.Show();
    }

    public void SetDeathScreens()
    {
        _overlay.Hide();
        _pauseScreen.Hide();
        _deathScreen.Show();
    }

    public void SetPauseScreens()
    {
        _overlay.Hide();
        _deathScreen.Hide();
        _pauseScreen.Show();
    }
}