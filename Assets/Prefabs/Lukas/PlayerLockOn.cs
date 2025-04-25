using UnityEngine;

public class PlayerLockOn : MonoBehaviour
{
    public float lockOnRange = 5f;
    public Weapon sword;
    public Weapon hammer;

    private Weapon equippedWeapon;

    void Start()
    {
        // Default to sword on start
        equippedWeapon = sword;
        sword.gameObject.SetActive(true);
        hammer.gameObject.SetActive(false);
    }

    void Update()
    {
        // Switch to Sword
        if (Input.GetKeyDown(KeyCode.Q))
        {
            equippedWeapon = sword;
            sword.gameObject.SetActive(true);
            hammer.gameObject.SetActive(false);
        }

        // Switch to Hammer
        if (Input.GetKeyDown(KeyCode.E))
        {
            equippedWeapon = hammer;
            hammer.gameObject.SetActive(true);
            sword.gameObject.SetActive(false);
        }

        // Lock onto closest enemy
        if (Input.GetKeyDown(KeyCode.L))
        {
            LockOnToEnemy();
        }

        // Unlock from current target
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnlockTarget();
        }
    }

    private void LockOnToEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, lockOnRange, LayerMask.GetMask("Enemy"));
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (var enemyCollider in enemiesInRange)
        {
            float distance = Vector2.Distance(transform.position, enemyCollider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemyCollider.transform;
            }
        }

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
