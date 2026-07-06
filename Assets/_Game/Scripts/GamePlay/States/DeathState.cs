using UnityEngine;

public class DeathState : GameState
{
    public override void Enter()
    {
        Debug.Log("Entered death state");
        uiManager.SetDeathScreens();
    }

    public override void Exit()
    {
        Debug.Log("Exit death state");
    }
}