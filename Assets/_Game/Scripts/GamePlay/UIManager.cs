using System.Runtime.CompilerServices;

public class UIManager
{
    private readonly GamePlayOverlayScreen _overlay;
    private readonly DeathScreen _deathScreen;

    public UIManager(GamePlayOverlayScreen overlay, DeathScreen deathScreen)
    {
        _overlay = overlay;
        _deathScreen = deathScreen;
    }

    public void SetExploringScreens()
    {
        _deathScreen.Hide();
        _overlay.Show();
    }

    public void SetDeathScreens()
    {
        _overlay.Hide();
        _deathScreen.Show();
    }
}