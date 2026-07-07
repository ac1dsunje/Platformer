public class GameExploringState: GameState
{
    public GameExploringState(UIManager ui) : base(ui) { }
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