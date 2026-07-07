using _Game.Scripts.FSM;

namespace _Game.Scripts.GamePlay.States
{
public abstract class GameFsmState: FsmState
{
    protected UIManager uiManager;

    public GameFsmState(UIManager ui)
    {
        uiManager = ui;
    }
}
}