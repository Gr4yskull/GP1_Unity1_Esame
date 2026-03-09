using UnityEngine;
using System;

public class Player : MonoBehaviour,IDamageable
{
   [SerializeField] public float maxHP;
   public float currentHP;
   public static event Action OnPlayerDeath;
   public static event Action OnHit;
   EnemyDamage enemy;

    private void Start()
    {
        currentHP=maxHP;
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy=other.GetComponent<EnemyDamage>();
            TakeDamage(enemy.currentDamagePerHit);
            enemy.Despawn();
        }
       
    
    }

    public void TakeDamage(float damage)
    {
        currentHP-=damage;
        OnHit?.Invoke();

        if (currentHP <= 0)
        {
            Despawn();
        }
    }

    public void Despawn()
    {
        OnPlayerDeath?.Invoke();
    }
}
