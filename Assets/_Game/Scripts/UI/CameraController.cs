using UnityEngine;

public class CameraController: MonoBehaviour
{
    private Transform _target;
    private float _speed;

    public void Construct(Transform target, float speed)
    {
        _target = target;
        _speed = speed;
    }

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_target.position.x, _target.position.y, -10), _speed * Time.deltaTime);
    }
}