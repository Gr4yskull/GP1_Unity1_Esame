using UnityEngine;
using System.Collections.Generic;

public class AreaProjectiles : MonoBehaviour
{
    Rigidbody rb;
    public float speed=300f;
    [SerializeField] float damage;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] float radius;
    private bool hasExploded=false;
    private List <Enemy> enemy=new();

    //bullet movement
    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward*speed*Time.deltaTime,ForceMode.Impulse);
    }

    //when it hits something
    void OnTriggerEnter(Collider other)
    {
        if(hasExploded)
            return;

        if (other.CompareTag("Enemy"))
        {
            Collider[] explosionArea=Physics.OverlapSphere(transform.position,radius,interactableLayer);

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
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
