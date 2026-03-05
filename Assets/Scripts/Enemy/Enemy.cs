using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;
    [SerializeField] float speed;
    [SerializeField] public int coins;
    Rigidbody rb;
    EnemySpawner buff;

    protected virtual void Start()
    {
        currentHealth=maxHealth;
        //get rigidbody
        rb=GetComponent<Rigidbody>();
        //add force to the enemy 
        rb.AddForce(Vector3.left*speed*Time.deltaTime,ForceMode.Impulse);
    }

}
