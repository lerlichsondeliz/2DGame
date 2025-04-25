using UnityEngine;
using System.Collections;

public class Hammer : Weapon
{
    public float innerRange = 1f;
    public float outerRange = 2f;
    public float outerDamageMultiplier = 0.5f;
    public float stunDuration = 1.5f;

    public override void Attack()
    {
        Debug.Log("Hammer attack triggered!");

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
