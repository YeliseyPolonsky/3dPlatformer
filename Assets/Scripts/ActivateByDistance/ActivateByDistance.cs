#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private float _maxDistanceToActivate;

    private bool _isAvtive = true;
    private Activator _activator;

    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.ListToActivate.Add(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (_isAvtive)
        {
            if (distance > _maxDistanceToActivate + 2)
            {
                DisActivate();
            }
        }
        else
        {
            if (distance < _maxDistanceToActivate)
            {
                Activate();
            }
        }
    }

    private void Activate()
    {
        _isAvtive = true;
        gameObject.SetActive(true);
    }

    private void DisActivate()
    {
        _isAvtive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _activator.ListToActivate.Remove(this);
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, _maxDistanceToActivate);
    }
#endif
}