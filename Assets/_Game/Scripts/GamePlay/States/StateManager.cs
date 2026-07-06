using System;
using System.Collections.Generic;

public abstract class StateManager<TState> where TState : State
{
    private readonly Dictionary<Type, TState> _states = new();
    private TState _state;

    public void AddState(TState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void ChangeState<T>() where T : TState
    {
        if (IsInState<T>()) return;

        var type = typeof(T);

        if (_states.TryGetValue(type, out var state))
        {
            _state?.Exit();
            _state = state;
            _state.Enter();
        }
    }

    protected bool IsInState<T>() where T : TState
    {
        return _state?.GetType() == typeof(T);
    }
}