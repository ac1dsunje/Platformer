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

    public override void Do()
    {
        _timer += Time.deltaTime;

        if (_timer >= Platform.WaitTime)
        {
            IsComplete = true;
        }
    }
}