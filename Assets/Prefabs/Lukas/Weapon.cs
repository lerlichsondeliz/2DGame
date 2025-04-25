using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public int damage;
    public float attackRate = 1f;
    public Transform target; // The enemy this weapon is currently locked onto
    public float lockOnRange = 5f; // Range to find enemies for lock-on

    private float lastAttackTime = 0f;

    protected virtual void Update()
    {
        // Automatically find and lock on to the closest enemy
        AutoLockTarget();

        // Perform attack if there's a target and cooldown is met
        if (target != null && Time.time >= lastAttackTime + attackRate)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    // Abstract method for the actual attack logic in derived classes
    public abstract void Attack();

    // Automatically locks on to the closest enemy in range
    private void AutoLockTarget()
    {
        // Get all enemies in range
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, lockOnRange, LayerMask.GetMask("Enemy"));

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        // Find the closest enemy in range
        foreach (var enemyCollider in enemiesInRange)
        {
            float distance = Vector2.Distance(transform.position, enemyCollider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemyCollider.transform;
            }
        }

        // Set the closest enemy as the target
        target = closestEnemy;
    }

    // Lock onto a specific enemy
    public void LockOnTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Unlock the current enemy
    public void UnlockTarget()
    {
        target = null;
    }

    // Optional: Visualize the lock-on range in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, lockOnRange);
    }
}
