using _Game.Scripts.FSM;

namespace _Game.Scripts.GamePlay.States
{
public abstract class GameFsmState: FsmState
{
    protected readonly UIManager uiManager;

    protected GameFsmState(UIManager ui)
    {
        uiManager = ui;
    }
}
}