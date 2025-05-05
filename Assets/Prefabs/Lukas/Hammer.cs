using UnityEngine;
using System.Collections;

public class Hammer : Weapon
{
    public enum PlayerID { Player1, Player2 }
    public PlayerID owner = PlayerID.Player1;

    public float innerRange = 1f;
    public float outerRange = 2f;
    public float outerDamageMultiplier = 0.5f;
    public float stunDuration = 1.5f;

    private void Update()
    {
        if (owner == PlayerID.Player1 && Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
        else if (owner == PlayerID.Player2 && Input.GetKeyDown(KeyCode.O))
        {
            Attack();
        }
    }

    public override void Attack()
    {
        Debug.Log(owner + " hammer attack triggered!");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, outerRange);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                Enemy enemy = enemyCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    float distance = Vector2.Distance(transform.position, enemy.transform.position);

                    if (distance <= innerRange)
                    {
                        enemy.TakeDamage(damage);
                    }
                    else
                    {
                        enemy.TakeDamage(damage * outerDamageMultiplier);
                    }

                    StartCoroutine(FlashRed(enemy));
                    StartCoroutine(StunEnemy(enemy, stunDuration));
                }
            }
        }
    }

    public IEnumerator FlashRed(Enemy enemy)
    {
        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color original = sr.color;
            sr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sr.color = original;
        }
    }

    public IEnumerator StunEnemy(Enemy enemy, float duration)
    {
        enemy.Stun(duration);
        yield return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, innerRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, outerRange);
    }
}
