using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    
    private Transform _playerTransform;
    
    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    
    private void Update()
    {
        Vector3 toPayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPayer,Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotateSpeed);
        
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
