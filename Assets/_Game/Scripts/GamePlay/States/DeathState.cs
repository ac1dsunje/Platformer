public class DeathState : GameState
{
    public DeathState(UIManager ui) : base(ui) { }
    public override void Enter()
    {
        base.Enter();
        uiManager.SetDeathScreens();
    }

    public override void Exit()
    {
        base.Exit();
    }
}