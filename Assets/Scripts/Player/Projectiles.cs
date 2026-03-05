using System;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    Rigidbody rb;
    public float speed=300f;
    [SerializeField] float damage;
    public static event Action <float> OnEnemyHit;

    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward*speed*Time.deltaTime,ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        OnEnemyHit?.Invoke(damage);
        Destroy(gameObject);
    }
}
