using _Game.Scripts.FSM;

namespace _Game.Scripts.GamePlay.States
{
public abstract class GameFsmState: FsmState
{
    protected readonly UIManager UIManager;

    protected GameFsmState(UIManager ui)
    {
        UIManager = ui;
    }
}
}