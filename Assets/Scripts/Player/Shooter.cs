using UnityEngine;

public class Shooter : Turrets
{
    public float bulletRate;
      private void Update()
    {
        //timer runs
        timer+=Time.deltaTime;
        if (timer >= bulletRate)
        {
            //instantiate projectile
            GameObject projectile=Instantiate(bullet,transform.position,transform.rotation,transform);
            //timer resets
            timer=0;
        }
        
    }
}
