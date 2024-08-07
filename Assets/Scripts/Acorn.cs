using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxAngleForce;

    private void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        
        rigidbody.AddRelativeForce(0,0,_speed,ForceMode.VelocityChange);
        rigidbody.AddRelativeTorque(
            Random.Range(-_maxAngleForce,_maxAngleForce),
            Random.Range(-_maxAngleForce,_maxAngleForce),
            Random.Range(-_maxAngleForce,_maxAngleForce));
    }
}