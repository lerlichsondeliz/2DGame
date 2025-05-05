using UnityEngine;

public class Sword : Weapon
{
    public enum PlayerID { Player1, Player2 }
    public PlayerID owner = PlayerID.Player1;

    public float attackRange = 1.5f;
    public float knockbackForce = 20f;

    private Collider2D attackCollider;

    private void Start()
    {
        attackCollider = GetComponent<Collider2D>();
        if (attackCollider != null)
            attackCollider.isTrigger = true;
    }

    private void Update()
    {
        // Separate input based on which player this sword belongs to
        if (owner == PlayerID.Player1 && Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
        else if (owner == PlayerID.Player2 && Input.GetKeyDown(KeyCode.U))
        {
            Attack();
        }
    }

    public override void Attack()
    {
        Debug.Log(owner + " sword attack triggered!");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                Enemy enemy = enemyCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Debug.Log("Sword hit " + enemy.name);
                    enemy.TakeDamage(damage);

                    Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
                    if (enemyRb != null)
                    {
                        Vector2 knockbackDir = (enemy.transform.position - transform.position).normalized;
                        enemyRb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
                    }

                    StartCoroutine(FlashRed(enemy));
                }
            }
        }
    }

    private System.Collections.IEnumerator FlashRed(Enemy enemy)
    {
        SpriteRenderer enemySprite = enemy.GetComponent<SpriteRenderer>();
        if (enemySprite)
        {
            Color originalColor = enemySprite.color;
            enemySprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            enemySprite.color = originalColor;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
