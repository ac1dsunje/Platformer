public abstract class GameState: State
{
    protected UIManager uiManager;

    public GameState(UIManager ui)
    {
        uiManager = ui;
    }
}