using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public int damage;
    public float attackRate;
    public Transform target; // The target the weapon is locked onto

    // Time tracking for attack rate
    private float lastAttackTime = 0f;

    // Update method to handle weapon attacks based on attack rate
    void Update()
    {
        if (target != null && Time.time >= lastAttackTime + attackRate)
        {
            Attack();
            lastAttackTime = Time.time; // Reset the time for the next attack
        }
    }

    // Abstract method to be implemented by different weapons
    public abstract void Attack();

    // Method to lock on to a target
    public void LockOnTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Method to unlock the target
    public void UnlockTarget()
    {
        target = null;
    }
}
