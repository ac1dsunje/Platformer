using _Game.Scripts.Level.Platforms.MovingPlatform.State;
using UnityEngine;

namespace _Game.Scripts.Level.Platforms.MovingPlatform
{
[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatformController : MonoBehaviour
{
    [SerializeField] private MovingPoint[] _points;
    [SerializeField] private float _movementTime;
    [SerializeField] private float _waitingTime;

    public Rigidbody2D RigidBody { get; private set; }
    public float MovementTime => _movementTime;
    public float WaitTime => _waitingTime;
    public MovingPoint[] Points => _points;

    private MpFsmState _currentFsmState;
    private MpFsmMovingState _fsmMovingState;
    private MpFsmWaitingState _fsmWaitingState;

    private void OnValidate()
    {
        foreach (var point in _points)
        {
            if (!point.SetPoint) continue;
            point.Point = transform.position;
            point.SetPoint = false;
        }
    }

    private void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();

        _fsmMovingState = new MpFsmMovingState(this);
        _fsmWaitingState = new MpFsmWaitingState(this);

        ChangeState(_fsmMovingState);
    }

    private void Update()
    {
        _currentFsmState?.Do();

        if (_currentFsmState != null && _currentFsmState.IsComplete)
        {
            HandleStateCompletion();
        }
    }

    private void HandleStateCompletion()
    {
        if (_currentFsmState == _fsmMovingState)
        {
            ChangeState(_fsmWaitingState);
        }
        else if (_currentFsmState == _fsmWaitingState)
        {
            ChangeState(_fsmMovingState);
        }
    }

    private void ChangeState(MpFsmState newFsmState)
    {
        _currentFsmState?.Exit();
        _currentFsmState = newFsmState;
        _currentFsmState.Enter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(transform, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(null, true);
    }
}
}