using UnityEngine;

public class DeathState : GameState
{
    public DeathState(UIManager ui) : base(ui) { }
    public override void Enter()
    {
        base.Enter();
        uiManager.SetDeathScreens();

        Time.timeScale = 0f;
    }

    public override void Exit()
    {
        base.Exit();

        Time.timeScale = 1f;
    }
}