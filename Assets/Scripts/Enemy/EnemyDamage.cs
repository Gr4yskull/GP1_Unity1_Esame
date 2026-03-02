using UnityEngine;

public class EnemyDamage : Enemy,IDamageable
{
    float testdamage;
    void OnTriggerEnter(Collider other)
    {
       TakeDamage(testdamage);
        if (maxHealth <= 0)
        {
            Despawn();
        }
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth-=damage;
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }
}
