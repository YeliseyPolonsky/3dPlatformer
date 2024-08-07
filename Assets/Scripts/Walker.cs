using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private float _speed;

    [SerializeField] private Direction _direction = Direction.Left;
    [SerializeField] private float _stopPeriod;

    [SerializeField] private Transform _startRay;
    
    public UnityEvent LeftWalkEvent;
    public UnityEvent RightWalkEvent;

    private bool _isStoped;

    private void Start()
    {
        _rightPoint.parent = null;
        _leftPoint.parent = null;
    }

    private void Update()
    {
        if (_isStoped) return;

        if (_direction == Direction.Left)
        {
            transform.position -= Vector3.right * _speed * Time.deltaTime;

            if (transform.position.x < _leftPoint.position.x)
            {
                _direction = Direction.Right;
                _isStoped = true;
                Invoke(nameof(UnStop), _stopPeriod);
                
                RightWalkEvent?.Invoke();
            }
        }
        else if (_direction == Direction.Right)
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;

            if (transform.position.x > _rightPoint.position.x)
            {
                _direction = Direction.Left;
                _isStoped = true;
                Invoke(nameof(UnStop), _stopPeriod);

                LeftWalkEvent?.Invoke();
            }
        }

        if (Physics.Raycast(_startRay.position, Vector3.down, out RaycastHit hit))
        {
            transform.position = hit.point;
        }
    }

    private void UnStop() => _isStoped = false;
}