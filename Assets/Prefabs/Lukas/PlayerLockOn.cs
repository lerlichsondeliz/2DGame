using UnityEngine;

public class PlayerLockOn : MonoBehaviour
{
    public float lockOnRange = 5f;  // Range within which the player can lock on to an enemy
    public Weapon equippedWeapon;   // Reference to the player's equipped weapon

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) // Press "L" to lock onto an enemy
        {
            LockOnToEnemy();
        }

        if (Input.GetKeyDown(KeyCode.U)) // Press "U" to unlock the current target
        {
            UnlockTarget();
        }
    }

    private void LockOnToEnemy()
    {
        // Find all enemies within the lockOnRange
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, lockOnRange, LayerMask.GetMask("Enemy"));
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        // Find the closest enemy
        foreach (var enemyCollider in enemiesInRange)
        {
            float distance = Vector2.Distance(transform.position, enemyCollider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemyCollider.transform;
            }
        }

        // Lock onto the closest enemy if one was found
        if (closestEnemy != null)
        {
            equippedWeapon.LockOnTarget(closestEnemy);
        }
    }

    private void UnlockTarget()
    {
        equippedWeapon.UnlockTarget();
    }
}
