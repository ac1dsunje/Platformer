using _Game.Scripts.FSM;

namespace _Game.Scripts.GamePlay.States
{
public abstract class GameState: State
{
    protected UIManager uiManager;

    public GameState(UIManager ui)
    {
        uiManager = ui;
    }
}
}