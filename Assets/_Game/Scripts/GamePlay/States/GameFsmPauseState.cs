using UnityEngine;

namespace _Game.Scripts.GamePlay.States
{
public class GameFsmPauseState : GameFsmState
{
    public GameFsmPauseState(UIManager ui) : base(ui) { }
    public override void Enter()
    {
        base.Enter();
        uiManager.SetPauseScreens();

        Time.timeScale = 0f;
    }

    public override void Exit()
    {
        Time.timeScale = 1f;
    }
}
}