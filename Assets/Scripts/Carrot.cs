using UnityEngine;

public class Carrot : MonoBehaviour
{
    public float Velocity;

    void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform playerTransform = FindObjectOfType<PlayerMove>().transform;

        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        GetComponent<Rigidbody>().velocity = toPlayer * Velocity;
    }
}