using UnityEngine;

public abstract class State
{
    public bool IsComplete { get; protected set; }

    public virtual void Enter()
    {
        IsComplete = false;
        Debug.Log($"Entered {GetType().Name}");
    }

    public virtual void Exit()
    {
        Debug.Log($"Exited {GetType().Name}");
    }

    public virtual void FixedDo() { }
}
