public class ExploringState: GameState
{
    public override void Enter()
    {
        base.Enter();

        uiManager.SetExploringScreens();
    }

    public override void Exit()
    {
        base.Exit();
    }
}