using System;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private RopeGun _ropeGun;
    public Rigidbody Rigidbody;

    private FixedJoint _fixedJoint;

    private void OnCollisionEnter(Collision other)
    {
        if (_fixedJoint)
            Destroy(_fixedJoint);

        _fixedJoint = gameObject.AddComponent<FixedJoint>();

        Rigidbody rb = other.rigidbody;
        if (rb)
            _fixedJoint.connectedBody = rb;

        _ropeGun.Spring();
    }

    public void StopFix()
    {
        Destroy(_fixedJoint);
    }
}