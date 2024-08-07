using UnityEngine;

public enum RopeState
{
    Disable,
    Active,
    Fly
}

public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Line _line;
    [SerializeField] private PlayerMove _playerMove;

    [SerializeField] private Transform _startHook;
    [SerializeField] private Transform _spawner;
    [SerializeField] private float _speed;

    [Header("IgnoreColloders")] [SerializeField]
    private Collider _collider;

    [SerializeField] private Collider _playerCollider;

    public float Length;
    private SpringJoint _springJoint;

    public RopeState RopeState;


    private void Start()
    {
        Physics.IgnoreCollision(_collider, _playerCollider);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (RopeState == RopeState.Active && _playerMove.Grounded == false)
            {
                _playerMove.Jump();
            }
            
            DestroyRope();
        }

        if (RopeState == RopeState.Fly)
        {
            Length = Vector3.Distance(_startHook.position, _hook.transform.position);

            if (Length > 20)
            {
                DestroyRope();
                RopeState = RopeState.Disable;
            }
        }

        if (RopeState == RopeState.Fly || RopeState == RopeState.Active)
        {
            _line.Draw(_startHook.position,_hook.transform.position,Length);
        }
    }

    private void Shot()
    {
        DestroyRope();
        
        RopeState = RopeState.Fly;
        _hook.gameObject.SetActive(true);

        _hook.transform.position = _spawner.position;
        _hook.transform.rotation = _spawner.rotation;


        _hook.Rigidbody.velocity = _speed * _spawner.forward;
    }

    public void Spring()
    {
        RopeState = RopeState.Active;

        if (_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.anchor = _startHook.localPosition;
            _springJoint.connectedBody = _hook.Rigidbody;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = 100;
            _springJoint.damper = 5;

            Length = Vector3.Distance(_startHook.position, _hook.transform.position);
            _springJoint.maxDistance = Length;
        }
    }

    public void DestroyRope()
    {
        RopeState = RopeState.Disable;

        Destroy(_springJoint);
        _hook.StopFix();
        
        _line.Hide();
        _hook.gameObject.SetActive(false);
    }
}