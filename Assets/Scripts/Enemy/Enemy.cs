using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;
    [SerializeField] public float damagePerHit;
    [SerializeField] float speed;
    [SerializeField] public int coins;
    Rigidbody rb;

    public void Start()
    {
        currentHealth=maxHealth;
        //get rigidbody
        rb=GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left*speed*Time.deltaTime,ForceMode.Impulse);
    }

}
