using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private bool isPlayer = false;
    [SerializeField] private Text deathText;

    private DamageFlash damageFlash;
    private DamageDisplay damageDisplay;

    public delegate void HealthChange(int currentHealth, int maxHealth);
    public event HealthChange OnHealthChanged;

    public event System.Action OnDeath; // Here's your new OnDeath event declaration

    private void Start()
    {
        currentHealth = maxHealth;
        if (deathText) deathText.enabled = false;
    }

    private void Awake()
    {
        damageFlash = GetComponent<DamageFlash>();
        damageDisplay = FindObjectOfType<DamageDisplay>();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"{gameObject.name} took {damage} damage.");
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (damageFlash)
            damageFlash.Flash();

        if (damageDisplay)
            damageDisplay.DisplayDamage(damage, transform.position);

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

    private void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        OnDeath?.Invoke();  // Here's where the OnDeath event is invoked

        if (!deathText) Debug.LogError("deathText is not assigned.");

        if (isPlayer && deathText)
            deathText.enabled = true;

        Destroy(gameObject);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
