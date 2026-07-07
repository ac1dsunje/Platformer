using UnityEngine;

public class GamePauseState : GameState
{
    public GamePauseState(UIManager ui) : base(ui) { }
    public override void Enter()
    {
        base.Enter();
        uiManager.SetPauseScreens();

        Time.timeScale = 0f;
    }

    public override void Exit()
    {
        base.Exit();

        Time.timeScale = 1f;
    }
}