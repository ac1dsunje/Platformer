using _Game.Scripts.GamePlay;
using _Game.Scripts.GamePlay.States;
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
        Time.timeScale = 1f;
    }
}