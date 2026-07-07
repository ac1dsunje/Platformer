using UnityEngine;

namespace _Game.Scripts.GamePlay.States
{
public class GameFsmDeathState : GameFsmState
{
    public GameFsmDeathState(UIManager ui) : base(ui) { }
    public override void Enter()
    {
        base.Enter();
        UIManager.SetDeathScreens();

        Time.timeScale = 0f;
    }

    public override void Exit()
    {
        base.Exit();

        Time.timeScale = 1f;
    }
}
}