using UnityEngine;

public class MGProjectiles : MonoBehaviour
{
    Rigidbody rb;
    public float speed=300f;
    [SerializeField] float damage;

    private void Start()
    {
        //gets rigidbody and moves projectile
        rb=GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward*speed*Time.deltaTime,ForceMode.Impulse);
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
                enemyHit.TakeDamage(damage);
            }
        }

        //despawns if it hits an enemy or the projectile remover
        Destroy(gameObject);
    }
}
