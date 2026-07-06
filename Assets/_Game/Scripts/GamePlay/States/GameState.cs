public abstract class GameState
{
    protected UIManager uiManager;

    public void Setup(UIManager ui)
    {
        uiManager = ui;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }
}