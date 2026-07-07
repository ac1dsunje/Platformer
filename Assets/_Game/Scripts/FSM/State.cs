using UnityEngine;

namespace _Game.Scripts.FSM
{
public abstract class State
{
    public bool IsComplete { get; protected set; }

    public virtual void Enter()
    {
        IsComplete = false;
    }

    public virtual void Exit() { }

    public virtual void FixedDo() { }
    public virtual void Do() { }
}
}
