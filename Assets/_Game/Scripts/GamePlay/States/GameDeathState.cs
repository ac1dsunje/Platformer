using UnityEngine;

public class GameDeathState : GameState
{
    public GameDeathState(UIManager ui) : base(ui) { }
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