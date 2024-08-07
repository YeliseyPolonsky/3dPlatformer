using UnityEngine;

public class LootHeal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
            
            if (playerHealth)
            {
                playerHealth.AddHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
