using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public int damage;
    public float attackRate = 1f;
    public Transform target;
    public float lockOnRange = 5f;

    protected Animator anim;
    private float lastAttackTime = 0f;

    protected virtual void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    protected virtual void Update()
    {
        AutoLockTarget();

        if (target != null && Time.time >= lastAttackTime + attackRate)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    public abstract void Attack();

    private void AutoLockTarget()
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

        target = closestEnemy;
    }

    public void LockOnTarget(Transform newTarget) => target = newTarget;
    public void UnlockTarget() => target = null;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, lockOnRange);
    }
}