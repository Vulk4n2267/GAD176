using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public Health playerHealth;

    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        if (playerHealth == null) return;

        // Initialize UI
        UpdateHealthUI(0);

        // Subscribe to events
        playerHealth.OnDamageTaken += UpdateHealthUI;
        playerHealth.OnDeath += OnPlayerDeath;
    }

    private void UpdateHealthUI(float damage)
    {
        float current = playerHealth.CurrentHealth;
        float max = 100f; 

        healthSlider.value = current / max;

        if (healthText != null)
        {
            healthText.text = $"{current} / {max}";
        }
    }

    private void OnPlayerDeath()
    {
        if (healthText != null)
        {
            healthText.text = "DEAD";
        }
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnDamageTaken -= UpdateHealthUI;
            playerHealth.OnDeath -= OnPlayerDeath;
        }
    }
}