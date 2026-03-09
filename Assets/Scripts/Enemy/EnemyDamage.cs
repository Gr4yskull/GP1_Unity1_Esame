using System;
using UnityEngine;

public class EnemyDamage : Enemy,IDamageable
{
    private float damagePerHit;
    public float currentDamagePerHit;
    public static event Action <int> OnEnemyDeath;
    public static event Action OnKill;


    public void SetAttack(float buff)
    {
        currentDamagePerHit=damagePerHit+buff;
    }
    public void TakeDamage(float damage)
    {
        currentHealth-=damage;
        if (currentHealth <= 0)
        {
            OnKill?.Invoke();
            Despawn();
        }
    }

    public void Despawn()
    {
        OnEnemyDeath?.Invoke(coins);
        Destroy(this.gameObject);
    }
}
