using UnityEngine;

public class MPWaitingState : MPState
{
    private float _timer;

    public MPWaitingState(MovingPlatformController context) : base(context) { }

    public override void Enter()
    {
        base.Enter();
        _timer = 0f;
    }

    public override void FixedDo()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer >= Context.WaitTime)
        {
            IsComplete = true;
        }
    }
}