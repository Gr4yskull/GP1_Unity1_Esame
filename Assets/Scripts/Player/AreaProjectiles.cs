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
        Debug.Log(radius);
        currentRadius=radius;
        rb=GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*speed*Time.deltaTime,ForceMode.Impulse);
    }

    //when it hits something
    void OnTriggerEnter(Collider other)
    {
        if(hasExploded)
            return;

        if (other.CompareTag("Enemy"))
        {
            Collider[] explosionArea=Physics.OverlapSphere(transform.position,currentRadius,interactableLayer);

            foreach(Collider enemy in explosionArea)
            {
                enemy.TryGetComponent(out IDamageable damageable);
                damageable.TakeDamage(damage);
                Debug.Log("COLPITO");
                hasExploded=true;
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
