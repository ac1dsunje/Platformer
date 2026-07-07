using UnityEngine;

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

    private MPState _currentState;
    private MPMovingState _movingState;
    private MPWaitingState _waitingState;

    private void OnValidate()
    {
        foreach (var point in _points)
        {
            if(point.SetPoint)
            {
                point.Point = transform.position;
                point.SetPoint = false;
            }
        }
    }

    private void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();

        _movingState = new MPMovingState(this);
        _waitingState = new MPWaitingState(this);

        ChangeState(_movingState);
    }

    private void Update()
    {
        _currentState?.Do();

        if (_currentState != null && _currentState.IsComplete)
        {
            HandleStateCompletion();
        }
    }

    private void HandleStateCompletion()
    {
        if (_currentState == _movingState)
        {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(transform, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(null, true);
    }
}