using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 _startPoint;
    [SerializeField] private Vector2 _endPoint;
    [SerializeField] private float _movementTime;
    [SerializeField] private float _waitingTime;


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
}