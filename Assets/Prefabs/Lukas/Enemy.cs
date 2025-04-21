using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float attackRange = 1.5f;  // Melee attack range
    public float attackCooldown = 1f; // Cooldown between attacks
    protected float lastAttackTime = 0f;

    public LayerMask obstacleMask;

    public float maxHealth = 100f;  // Max health for the enemy
    public float currentHealth;  // Current health of the enemy

    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer for color change
    protected Color originalColor;  // Store the original color of the enemy

    public float flashDuration = 0.2f; // How long the enemy flashes red

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component
        originalColor = spriteRenderer.color;  // Store the original color
        currentHealth = maxHealth;  // Initialize health
    }

    protected virtual void FixedUpdate()
    {
        if (player == null) return;

        // Calculate the distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if enough time has passed to attack again
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            // Check if the enemy is within range to attack
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
    }

    protected void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        // Raycast to check for obstacles
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1.5f, obstacleMask);
        if (hit.collider != null)
        {
            // Try sidestepping if an obstacle is detected
            direction = Vector2.Perpendicular(direction).normalized;
        }

        rb.linearVelocity = direction * speed;  // Ensure to use rb.velocity instead of linearVelocity
    }

    // Abstract method for attack behavior (to be implemented by derived classes)
    protected abstract void AttackPlayer();

    // Method to handle damage to the enemy
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;  // Subtract the damage from current health

        if (currentHealth <= 0)
        {
            Die();  // If health reaches zero, die
        }
        else
        {
            // Trigger the red flash effect when damaged
            StartCoroutine(FlashRed());
        }
    }

    // Coroutine to handle the red flash effect
    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;  // Change the color to red
        yield return new WaitForSeconds(flashDuration);  // Wait for the specified flash duration
        spriteRenderer.color = originalColor;  // Revert back to the original color
    }

    // Handle enemy death (this can be overridden in derived classes if needed)
    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject);  // Destroy the enemy GameObject
    }
}
