using UnityEngine;

public class EnemyMakeDamageOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.attachedRigidbody)
        {
            PlayerHealth playerHealth = other.collider.attachedRigidbody.GetComponent<PlayerHealth>();
            
            if (playerHealth)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}
