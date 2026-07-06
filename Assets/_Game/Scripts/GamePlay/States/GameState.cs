using UnityEngine;

public abstract class GameState
{
    protected UIManager uiManager;

    public GameState(UIManager ui)
    {
        uiManager = ui;
    }

    public virtual void Enter()
    {
        Debug.Log($"Entered {GetType().Name}");
    }

    public virtual void Exit()
    {
        Debug.Log($"Exited {GetType().Name}");
    }
}