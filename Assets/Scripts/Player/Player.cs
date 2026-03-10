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
    
    //when something collides if it is an enemy
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //deals damage to the player and destroys the enemy
            enemy=other.GetComponent<EnemyDamage>();
            TakeDamage(enemy.currentDamagePerHit);
            Destroy(enemy.gameObject);
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
