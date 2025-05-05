using UnityEngine;
using System.Collections;
using System.Linq;

public abstract class Enemy : MonoBehaviour
{
    private Transform[] players;
    protected Transform targetPlayer;

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

    private bool isStunned = false;
    private float stunEndTime = 0f;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        currentHealth = maxHealth;

        players = GameObject.FindGameObjectsWithTag("Player")
                            .Select(go => go.transform)
                            .ToArray();
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
                rb.linearVelocity = Vector2.zero;
                return;
            }
        }

        UpdateTargetPlayer();

        if (targetPlayer == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, targetPlayer.position);

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

    private void UpdateTargetPlayer()
    {
        float minDistance = float.MaxValue;
        Transform closest = null;

        foreach (var p in players)
        {
            if (p == null) continue;
            float dist = Vector2.Distance(transform.position, p.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                closest = p;
            }
        }

        targetPlayer = closest;
    }

    protected void MoveTowardsPlayer()
    {
        if (targetPlayer == null) return;

        Vector2 direction = (targetPlayer.position - transform.position).normalized;

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
        if (spriteRenderer == null) yield break;

        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flashDuration);

        if (spriteRenderer != null)
            spriteRenderer.color = originalColor;
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject);
    }

    public void Stun(float duration)
    {
        isStunned = true;
        stunEndTime = Time.time + duration;
        rb.linearVelocity = Vector2.zero;
        Debug.Log(gameObject.name + " is stunned for " + duration + " seconds");
    }
}
