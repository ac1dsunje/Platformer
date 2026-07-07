using _Game.Scripts.GamePlay;
using _Game.Scripts.GamePlay.States;
using UnityEngine;

public class GameFsmDeathState : GameFsmState
{
    public GameFsmDeathState(UIManager ui) : base(ui) { }
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