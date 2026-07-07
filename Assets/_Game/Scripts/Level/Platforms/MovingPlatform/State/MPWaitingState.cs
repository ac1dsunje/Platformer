using UnityEngine;

namespace _Game.Scripts.Level.Platforms.MovingPlatform.State
{
public class MpWaitingState : MpState
{
    private float _timer;

    public MpWaitingState(MovingPlatformController context) : base(context) { }

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
}