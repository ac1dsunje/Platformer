using UnityEngine;

namespace _Game.Scripts.Level.Platforms.MovingPlatform.State
{
public class MpFsmMovingState : MpFsmState
{
    private float _speed;
    private int _pointIndex;
    private Vector3 _currentTarget;

    public MpFsmMovingState(MovingPlatformController platform) : base(platform) { }

    public override void Enter()
    {
        base.Enter();
        _currentTarget = Platform.Points[_pointIndex].Point;
        var distance = Vector3.Distance(Platform.transform.position, _currentTarget);
        _speed = distance / Platform.MovementTime;
    }

    public override void Do()
    {
        Platform.transform.position = Vector3.MoveTowards(
            Platform.transform.position,
            _currentTarget,
            _speed * Time.deltaTime
        );

        if (Platform.transform.position == _currentTarget)
        {
            IsComplete = true;
        }
    }

    public override void Exit()
    {
        SetNextIndex();
    }

    private void SetNextIndex()
    {
        _pointIndex++;
        if (_pointIndex >= Platform.Points.Length)
        {
            _pointIndex = 0;
        }
    }
}
}