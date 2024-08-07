using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Health;
    public UnityEvent OnTakeDamageEvent;
    public UnityEvent OnDie;

    public void TakeDamage(int damageValue)
    {
        Health -= damageValue;

        if (Health <= 0)
        {
            Die();
        }
        
        OnTakeDamageEvent?.Invoke();
    }

    public void Die()
    {
        OnDie?.Invoke();
        Destroy(gameObject);
    }
}
