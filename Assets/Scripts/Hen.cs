using UnityEngine;

public class Hen : MonoBehaviour
{
    public float MaxSpeed;
    public float TimeToReach;

    private Rigidbody _rb;
    private Transform _playerTransform;
    
    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rb.mass * (MaxSpeed * toPlayer - _rb.velocity) / TimeToReach;
        
        _rb.AddForce(force);
    }
}
