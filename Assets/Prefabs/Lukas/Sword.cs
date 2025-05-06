using UnityEngine;

public class Sword : Weapon
{
    public float attackRange = 1.5f;
    public float knockbackForce = 20f;

    public override void Attack()
    {
        Debug.Log("Sword attack triggered!");
        if (anim != null)
        {
            anim.SetTrigger("Attack"); // Make sure "Attack" Trigger exists in Animator
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D enemyCollider in hitEnemies)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                Enemy enemy = enemyCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
                    if (enemyRb != null)
                    {
                        Vector2 knockbackDir = (enemy.transform.position - transform.position).normalized;
                        enemyRb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}