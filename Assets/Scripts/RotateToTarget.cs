using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private Vector3 _leftRatation;
    [SerializeField] private Vector3 _rightRotation;
    [SerializeField] private float _speed = 5f;
    
    private Vector3 _targetRotation;

    public void RotateToRight() => _targetRotation = _rightRotation;

    public void RotateToLeft() => _targetRotation = _leftRatation;
    
    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetRotation),Time.deltaTime * _speed ) ;
    }
}
