using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private Transform _body;
    
    private float _yEuler;
    private Vector3 _leftROtation = new Vector3(0,45,0);
    private Vector3 _rightRotation= new Vector3(0,-45,0);

    private void Update()
    {
        Vector3 targetRotation = _aim.position.x > _body.position.x ? _rightRotation : _leftROtation;
        _body.localRotation = Quaternion.Lerp(_body.localRotation,Quaternion.Euler(targetRotation),Time.deltaTime*8f);
    }

    private void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        plane.Raycast(ray, out float distanse);
        Vector3 pointPosition = ray.GetPoint(distanse);

        _aim.position = pointPosition;
        Vector3 toAim = _aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}