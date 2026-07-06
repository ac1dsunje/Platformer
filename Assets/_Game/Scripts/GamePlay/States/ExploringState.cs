using UnityEngine;

public class ExploringState: GameState
{
    public override void Enter()
    {
        Debug.Log("Entered exploring state");
        uiManager.SetExploringScreens();
    }

    public override void Exit()
    {
        Debug.Log("Exit exploring state");
    }
}