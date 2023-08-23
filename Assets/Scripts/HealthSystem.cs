using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private DamageEffects damageEffects; // Reference to DamageEffects

    public delegate void HealthChange(int currentHealth, int maxHealth);
    public event HealthChange OnHealthChanged;

    public event Action OnDamaged;
    public event Action OnDeath;

    private void Awake()
    {
        damageEffects = GetComponent<DamageEffects>(); // Get the DamageEffects component
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"{gameObject.name} took {damage} damage.");
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        OnDamaged?.Invoke();

        // Trigger DamageEffects when damaged
        if(damageEffects != null)
        {
            damageEffects.Flash(); // Flash the sprite
            damageEffects.DisplayDamage(damage, transform.position); // Display the damage text
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Die()
    {
        // Trigger the OnDeath event
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
