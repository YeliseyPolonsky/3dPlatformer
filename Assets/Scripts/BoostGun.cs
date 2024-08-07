using UnityEngine;

public class BoostGun : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Gun _pistol;
    [SerializeField] private ChargeIcon _chargeIcon;

    private Rigidbody _rigidbody;
    
    [SerializeField] private float _maxCharge;
    private float _currentCharge;
    private bool _isCharged;

    private void Start()
    {
        _rigidbody = FindObjectOfType<PlayerMove>().GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _rigidbody.AddForce(-transform.forward*_speed,ForceMode.VelocityChange);
                _pistol.Shot();

                _currentCharge = 0;
                _isCharged = false;
                _chargeIcon.StartCharge();
            }
        }
        else
        {
            _chargeIcon.ChangeIcon(_currentCharge,_maxCharge);
            _currentCharge += Time.unscaledDeltaTime;

            if (_currentCharge >= _maxCharge)
            {
                _chargeIcon.StopCharge();
                _isCharged = true;
            }
        }
    }
}
