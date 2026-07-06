using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 _startPoint;
    [SerializeField] private Vector2 _endPoint;
    [SerializeField] private float _movementTime;
    [SerializeField] private float _waitingTime;

    private enum State
    {
        moving,
        waiting
    }

    private State _state;

    private Rigidbody2D _rb;

    private Vector2 _target;
    private float _speed;
    private Coroutine _waitingCoroutine;

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
        _rb = GetComponent<Rigidbody2D>();

        float distance = Vector2.Distance(_startPoint, _endPoint);
        _speed = distance / _movementTime;

        ChangeState(State.moving);
        SwitchTarget();
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(_waitingTime);
        ChangeState(State.moving);
        SwitchTarget();
    }

    private void FixedUpdate()
    {
        if (_state != State.moving) return;

        Vector2 newPosition = Vector2.MoveTowards(_rb.position, _target, _speed * Time.fixedDeltaTime);
        _rb.MovePosition(newPosition);

        if (_rb.position == _target)
        {
            _waitingCoroutine = StartCoroutine(Waiting());
            ChangeState(State.waiting);
        }
    }

    private void SwitchTarget()
    {
        if (_target == _startPoint)
        {
            _target = _endPoint;
        }
        else
        {
            _target = _startPoint;
        }
    }

    private void OnDestroy()
    {
        if (_waitingCoroutine != null)
        {
            StopCoroutine(_waitingCoroutine);
        }
    }

    private void ChangeState(State state)
    {
        _state = state;
    }
}