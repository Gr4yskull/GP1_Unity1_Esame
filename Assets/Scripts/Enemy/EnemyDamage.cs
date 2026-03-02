using UnityEngine;

public class EnemyDamage : MonoBehaviour,IDamageable
{
    float testdamage;
    void OnTriggerEnter(Collider other)
    {
       TakeDamage(testdamage);
       Despawn(); 
    }

    public void TakeDamage(float danno)
    {
        
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }
}
