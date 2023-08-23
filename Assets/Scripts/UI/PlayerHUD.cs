using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Text healthText;
    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = FindObjectOfType<HealthSystem>();
        healthSystem.OnHealthChanged += UpdateHealthText;
    }

    private void UpdateHealthText(int currentHealth, int maxHealth)
    {
        if (healthText)
            healthText.text = $"{currentHealth}/{maxHealth}";
    }
}
