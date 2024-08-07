using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;

    private void Update() => transform.position = _targetTransform.position;
}