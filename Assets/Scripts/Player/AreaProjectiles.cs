using UnityEngine;
using System;
using System.Collections.Generic;

public class AreaProjectiles : MonoBehaviour
{
  Rigidbody rb;
    public float speed=300f;
    [SerializeField] float damage;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] float radius;
    private List <Enemy> enemies=new();
    public static event Action <float> OnEnemyHit;

    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward*speed*Time.deltaTime,ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Collider[] explosionArea=Physics.OverlapSphere(transform.position,radius,interactableLayer);

            foreach(Collider enemy in explosionArea)
            {
                
            }
        }
        //OnEnemyHit?.Invoke(damage);
        
        //Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

