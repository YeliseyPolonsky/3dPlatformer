using UnityEngine;

public class EnemyMakeDamageOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
            
            if (playerHealth)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}
