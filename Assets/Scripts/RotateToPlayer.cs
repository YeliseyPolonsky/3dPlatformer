using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private float _leftAngle;
    [SerializeField] private float _rightAngle;
    private float _targetAngle;
    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMove>().transform;
    }
    
    void Update()
    {
        Vector3 toPlayer = _player.position - transform.position;
        float vectorX = toPlayer.x;
        
        if (vectorX > 0)
        {
            _targetAngle = _rightAngle;
        }else if (vectorX < 0)
        {
            _targetAngle = _leftAngle;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(new Vector3(0,_targetAngle,0)),Time.deltaTime*5f );
    }
}
