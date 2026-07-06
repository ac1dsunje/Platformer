public class PauseState : GameState
{
    public PauseState(UIManager ui) : base(ui) { }
    public override void Enter()
    {
        base.Enter();
        uiManager.SetPauseScreens();
    }

    public override void Exit()
    {
        base.Exit();
    }
}