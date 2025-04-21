using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;  // The player's maximum health
    private float currentHealth;     // The player's current health

    public float CurrentHealth => currentHealth;  // Property to access current health

    void Start()
    {
        currentHealth = maxHealth;  // Initialize the player's health
    }

    // Method to reduce health when taking damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;  // Reduce health by damage

        if (currentHealth <= 0)
        {
            Die();  // If health is 0 or less, handle death
        }
    }

    // Handle player death (this could be restarting the level, showing game over, etc.)
    private void Die()
    {
        Debug.Log("Player has died!");
        // You can add game over logic here, like showing a game over screen
        // For now, let's just disable the player GameObject
        gameObject.SetActive(false);  // Disable the player object (you could restart or display game over)
    }
}
