using UnityEngine;

public class Projectiles : MonoBehaviour
{
    Rigidbody rb;
    float speed=300f;

    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward*speed*Time.deltaTime,ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
