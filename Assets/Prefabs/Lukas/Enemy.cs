using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;
    protected float lastAttackTime = 0f;

    public LayerMask obstacleMask;

    public float maxHealth = 100f;
    public float currentHealth;

    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected Color originalColor;

    public float flashDuration = 0.2f;

    // --- Stun fields ---
    private bool isStunned = false;
    private float stunEndTime = 0f;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        if (isStunned)
        {
            if (Time.time >= stunEndTime)
            {
                isStunned = false;
            }
            else
            {
                rb.linearVelocity = Vector2.zero; // Stop moving while stunned
                return; // Skip actions while stunned
            }
        }

        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (Time.time >= lastAttackTime + attackCooldown)
        {
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

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1.5f, obstacleMask);
        if (hit.collider != null)
        {
            direction = Vector2.Perpendicular(direction).normalized;
        }

        rb.linearVelocity = direction * speed;
    }

    protected abstract void AttackPlayer();

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(FlashRed());
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject);
    }

    // --- Called by weapons to apply stun ---
    public void Stun(float duration)
    {
        isStunned = true;
        stunEndTime = Time.time + duration;
        rb.linearVelocity = Vector2.zero;
        Debug.Log(gameObject.name + " is stunned for " + duration + " seconds");
    }
}
