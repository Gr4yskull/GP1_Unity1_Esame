using UnityEngine;
using System.Collections.Generic;

public class AreaProjectiles : UpgradeManager
{
    Rigidbody rb;
    public float speed=300f;
    [SerializeField] float damage;
    [SerializeField] private LayerMask interactableLayer;
    public static float radius=0.5f;
    [SerializeField] float currentRadius;

    private bool hasExploded=false;

    //bullet movement
    private void Start()
    {
        currentRadius=radius;
        rb=GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*speed*Time.deltaTime,ForceMode.Impulse);
    }

    //when it hits something
    void OnTriggerEnter(Collider other)
    {
        if(hasExploded)
            return;

        //checks tag
        if (other.CompareTag("Enemy"))
        {
            //gets collider
            Collider[] explosionArea=Physics.OverlapSphere(transform.position,currentRadius,interactableLayer);

            //for each collider got
            foreach(Collider enemy in explosionArea)
            {
                //checks component
                if(enemy.TryGetComponent(out IDamageable damageable))
                {
                    //deals damage
                    damageable.TakeDamage(damage);
                    //bool to prevent it from dealing double damage
                    hasExploded=true;
                }
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, currentRadius);
    }
}
