using UnityEngine;

public class MeleeEnemy : Enemy
{
    public int meleeDamage = 10;

    protected override void AttackPlayer()
    {
        Debug.Log("Melee attack on player!");
        if (targetPlayer != null && targetPlayer.TryGetComponent<PlayerHealth>(out var health))
        {
            health.TakeDamage(meleeDamage);
        }
        lastAttackTime = Time.time;
    }

    public void OnProjectileHit(float damage)
    {
        TakeDamage(damage);
    }
}
