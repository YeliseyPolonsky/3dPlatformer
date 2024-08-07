using UnityEngine;

public class EnemyTakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    [SerializeField] private bool _isDieOnEnyCollodion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TakeDamage(1);
            }
        }

        if (_isDieOnEnyCollodion && other.isTrigger == false)
        {
            EnemyHealth.TakeDamage(1000);
        }
    }
}