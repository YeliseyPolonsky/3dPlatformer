using UnityEngine;

public class EnemyTakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool IsOnAnyCollisionDie;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.attachedRigidbody)
        {
            if (other.collider.attachedRigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TakeDamage(1);
            }
        }

        if (IsOnAnyCollisionDie)
        {
            EnemyHealth.TakeDamage(1000);
        }
    }
}