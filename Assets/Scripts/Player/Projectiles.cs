using UnityEngine;


public class Projectiles : MonoBehaviour
{
    Rigidbody rb;
    public float speed=300f;
    [SerializeField] public static float damage=2;
    [SerializeField] private float currentDamage;

    private void Start()
    {
        //gets rigidbody and moves projectile
        rb=GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*speed*Time.deltaTime,ForceMode.Impulse);
        currentDamage=damage;
    }


    void OnTriggerEnter(Collider other)
    {
        //checks if it hit an eney
        if(other.CompareTag("Enemy"))
        {
            //gets interface
            IDamageable enemyHit=other.GetComponent<IDamageable>();

            //deals damage to enemy
            if (enemyHit != null)
            {
                enemyHit.TakeDamage(currentDamage);
            }
        }

        //despawns if it hits an enemy or the projectile remover
        Destroy(gameObject);
    }
}
