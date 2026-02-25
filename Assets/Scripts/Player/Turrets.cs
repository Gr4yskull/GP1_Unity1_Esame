using UnityEngine;

public class Turrets : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletRate;
    [SerializeField] float damage;
    [SerializeField] int cost;
    float timer;

    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer >= bulletRate)
        {
            Instantiate(bullet,transform.position,transform.rotation,transform);
            timer=0;
        }
        
    }
}
