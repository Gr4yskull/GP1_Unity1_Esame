using System;

public class EnemyDamage : Enemy,IDamageable
{
    
    public float damagePerHit;
    public float damageBuff;
    public static event Action <int> OnEnemyDeath;

    public void OnEnable()
    {
        Projectiles.OnEnemyHit+=TakeDamage;
    }

    public void OnDisable()
    {
        Projectiles.OnEnemyHit-=TakeDamage;
    }
    public void TakeDamage(float damage)
    {
        currentHealth-=damage;
        if (currentHealth <= 0)
        {
            Despawn();
        }
    }

    public void Despawn()
    {
        OnEnemyDeath?.Invoke(coins);
        Destroy(gameObject);
    }
}
