public class DeathState : GameState
{
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