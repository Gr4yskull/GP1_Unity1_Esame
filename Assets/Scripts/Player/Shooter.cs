using UnityEngine;

public class Shooter : Turrets
{
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
