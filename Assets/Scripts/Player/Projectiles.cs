using UnityEngine;

public class Projectiles : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
}
