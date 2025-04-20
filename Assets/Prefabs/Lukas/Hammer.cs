using UnityEngine;

public class Hammer : Weapon
{
    public float attackRange = 1f;  // The range at which the hammer can hit an enemy
    private Collider2D attackCollider; // Collider for detecting enemies

    private void Start()
    {
        attackCollider = GetComponent<Collider2D>();
        attackCollider.isTrigger = true; // Ensure the collider is set to trigger
    }

    public override void Attack()
    {
        Debug.Log("Hammer attack triggered!");

        // Find all enemies in range using Physics2D.OverlapCircle
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                Enemy enemy = enemyCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Debug.Log("Hammer hit " + enemy.name);
                    enemy.TakeDamage(damage);
                    StartCoroutine(FlashRed(enemy)); // Flash enemy red on hit
                }
            }
        }
    }

    // Stun Feature for Hammer

    

    private System.Collections.IEnumerator FlashRed(Enemy enemy)
    {
        SpriteRenderer enemySprite = enemy.GetComponent<SpriteRenderer>();
        if (enemySprite)
        {
            Color originalColor = enemySprite.color;
            enemySprite.color = Color.red; // Change color to red
            yield return new WaitForSeconds(0.1f); // Wait briefly
            enemySprite.color = originalColor; // Revert to original color
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizes the sword's attack range in Unity
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
