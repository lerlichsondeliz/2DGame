using UnityEngine;

public class MeleeEnemy : Enemy
{
    public int meleeDamage = 10;

    // Implement the attack behavior for the melee enemy
    protected override void AttackPlayer()
    {
        Debug.Log("Melee attack on player!");
        // Apply damage to the player (assuming player has a "PlayerHealth" script)
        player.GetComponent<PlayerHealth>().TakeDamage(meleeDamage);
        lastAttackTime = Time.time; // Reset attack cooldown
    }

    // Call TakeDamage when the enemy is hit by a projectile or other damage source
    public void OnProjectileHit(float damage)
    {
        TakeDamage(damage);  // Apply damage to the enemy
    }
}
