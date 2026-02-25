using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float damagePerHit;
    [SerializeField] float speed;
    Rigidbody rb;

    private void Start()
    {
        //get rigidbody
        rb=GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left*speed*Time.deltaTime,ForceMode.Impulse);
    }

}
