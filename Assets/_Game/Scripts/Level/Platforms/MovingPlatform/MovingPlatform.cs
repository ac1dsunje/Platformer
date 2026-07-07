using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatformController : MonoBehaviour
{
    [SerializeField] private Vector2 _startPoint;
    [SerializeField] private Vector2 _endPoint;
    [SerializeField] private float _movementTime;
    [SerializeField] private float _waitingTime;

    public Rigidbody2D RigidBody { get; private set; }
    public float Speed {get; private set;}
    public Vector2 CurrentTarget { get; private set; }

    public float WaitTime => _waitingTime;

    private MPState _currentState;
    private MPMovingState _movingState;
    private MPWaitingState _waitingState;

    [ContextMenu("Set Start Point")]
    private void SetStartPoint()
    {
        _startPoint = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f);
    }

    [ContextMenu("Set End Point")]
    private void SetEndPoint()
    {
        _endPoint = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f);
    }

    private void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();

        float distance = Vector2.Distance(_startPoint, _endPoint);
        Speed = distance / _movementTime;

        _movingState = new MPMovingState(this);
        _waitingState = new MPWaitingState(this);

        CurrentTarget = _endPoint;
        ChangeState(_movingState);
    }

    private void FixedUpdate()
    {
        _currentState?.FixedDo();

        if (_currentState != null && _currentState.IsComplete)
        {
            HandleStateCompletion();
        }
    }

    private void HandleStateCompletion()
    {
        if (_currentState == _movingState)
        {
            SwitchTarget();
            ChangeState(_waitingState);
        }
        else if (_currentState == _waitingState)
        {
            ChangeState(_movingState);
        }
    }

    private void ChangeState(MPState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    private void SwitchTarget()
    {
        CurrentTarget = (CurrentTarget == _startPoint) ? _endPoint : _startPoint;
    }
}