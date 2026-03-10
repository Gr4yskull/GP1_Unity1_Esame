using System;
using UnityEngine;

public class EnemyDamage : Enemy,IDamageable
{
    private float damagePerHit;
    public float currentDamagePerHit;
    public static event Action <int> OnEnemyDeath;
    public static event Action OnKill;

    //sets attack in case of buff
    public void SetAttack(float buff)
    {
        currentDamagePerHit=damagePerHit+buff;
    }
    //function applied when hit by a bullet
    public void TakeDamage(float damage)
    {
        currentHealth-=damage;
        if (currentHealth <= 0)
        {
            OnKill?.Invoke();
            Despawn();
        }
    }

    //gives coins and destroys object
    public void Despawn()
    {
        OnEnemyDeath?.Invoke(coins);
        Destroy(this.gameObject);
    }
}
