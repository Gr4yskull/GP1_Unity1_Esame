using UnityEngine;

public class Shooter : Turrets
{
    public float bulletRate;
      private void Update()
    {
        timer+=Time.deltaTime;
        if (timer >= bulletRate)
        {
            GameObject projectile=Instantiate(bullet,transform.position,transform.rotation,transform);
            timer=0;
        }
        
    }
}
