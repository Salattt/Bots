using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToStop;

    private Transform _transform;
    private Vector3 _target;
    private bool _isMoving = false;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if(_isMoving)
            GoToTarget();
    }

    public void SetupTarget(Vector3 target)
    {
        _target = target;
        _isMoving = true;
    }

    public void Stop()
    {
        _isMoving = false;
    }

    private void GoToTarget()
    {
        if ((_target - _transform.position).magnitude > _distanceToStop)
        {
            _transform.position += new Vector3(_target.x - _transform.position.x, 0, _target.z - _transform.position.z).normalized * Time.deltaTime * _speed;
        }
        else
        {
            _isMoving = false;
        }
    }
}
