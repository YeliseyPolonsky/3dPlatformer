using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public int MaxHealth;

    public UIHealth UIHealth;

    public AudioSource AddHealthAudio;

    private bool _invulnerable;

    public UnityEvent OnTakeDamageEvent;

    private void Start()
    {
        UIHealth.Setup(MaxHealth);
        UIHealth.DisplayHealth(Health);
    }

    public void TakeDamage(int damageValue)
    {
        if (!_invulnerable)
        {
            Health -= damageValue;

            if (Health <= 0)
            {
                Health = 0;
                Die();
            }

            _invulnerable = true;
            Invoke(nameof(UnInvulnerable), 1f);

            OnTakeDamageEvent.Invoke();
            UIHealth.DisplayHealth(Health);
        }
    }

    public void UnInvulnerable()
    {
        _invulnerable = false;
    }

    public void Die()
    {
        Debug.Log("You Loose");
    }

    public void AddHealth(int count)
    {
        Health += count;

        if (Health > MaxHealth)
            Health = MaxHealth;

        AddHealthAudio.Play();
        UIHealth.DisplayHealth(Health);
    }
}