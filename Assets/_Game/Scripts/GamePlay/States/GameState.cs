using UnityEngine;

public abstract class GameState: State
{
    protected UIManager uiManager;

    public void Setup(UIManager ui)
    {
        uiManager = ui;
    }

    public override void Enter()
    {
        Debug.Log($"Entered {GetType().Name}");
    }

    public override void Exit()
    {
        Debug.Log($"Exited {GetType().Name}");
    }
}