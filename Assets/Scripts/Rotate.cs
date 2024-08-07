using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 RotateSpeed;

    void Update()
    {
        transform.Rotate(RotateSpeed * Time.deltaTime);
    }
}