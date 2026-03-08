using System;
using UnityEngine;

public class EnemyDamage : Enemy,IDamageable
{
    
    public float damagePerHit;
    public float damageBuff;
    public static event Action <int> OnEnemyDeath;

    public void TakeDamage(float damage)
    {
         Debug.Log("DENTRO ENEMYDAMAGE");
        currentHealth-=damage;
        if (currentHealth <= 0)
        {
            Despawn();
        }
    }

    public void Despawn()
    {
        OnEnemyDeath?.Invoke(coins);
        Destroy(this.gameObject);
    }
}
