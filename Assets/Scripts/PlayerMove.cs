using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _speed;
    [SerializeField] private float _friction;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Transform _colliderTransform;
    
    public bool Grounded;

    private int _jumpFrameCounter;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !Grounded)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1, 0.5f, 1),
                Time.deltaTime * 15f);
        }
        else
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1, 1, 1),
                Time.deltaTime * 15f);
        }
        
        if (Grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            Jump();
        }
    }

    public void Jump()
    {
        _jumpFrameCounter = 0;
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    }

    private void FixedUpdate()
    {
        float speedMultiply = 1f;

        if (!Grounded)
        {
            speedMultiply = 0.2f;
            
            if (_rigidbody.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiply = 0;
            }
            if (-_rigidbody.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiply = 0;
            }
        }

        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _speed * speedMultiply, 0, 0, ForceMode.VelocityChange);
        
        if (Grounded)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.identity, Time.deltaTime * 15f);
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
        }

        _jumpFrameCounter++;

        if (_jumpFrameCounter == 2)
        {
            _rigidbody.freezeRotation = false;
            _rigidbody.AddRelativeTorque(0,0,10f,ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        for (int i = 0; i < other.contactCount; i++)
        {
            float angle = Vector3.Angle(Vector3.up, other.contacts[i].normal);

            if (angle < 45)
            {
                _rigidbody.freezeRotation = true;
                Grounded = true;
                break;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Grounded = false;
    }
}