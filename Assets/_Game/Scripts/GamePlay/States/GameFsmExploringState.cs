namespace _Game.Scripts.GamePlay.States
{
public class GameFsmExploringState: GameFsmState
{
    public GameFsmExploringState(UIManager ui) : base(ui) { }
    public override void Enter()
    {
        base.Enter();

        UIManager.SetExploringScreens();
    }
}
}