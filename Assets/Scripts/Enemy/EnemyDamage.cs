using UnityEngine;

public class EnemyDamage : Enemy,IDamageable
{
    public float damagePerHit;

    public void TakeDamage(float damage)
    {
        currentHealth-=damage;
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }
}
