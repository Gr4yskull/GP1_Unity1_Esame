using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy; 
    [SerializeField] float spawnRate; 
    float timer;
    int enemyIndex;
    public int spawnCounter=0;
    [SerializeField] float minRate;
    [SerializeField] float changedRate;
    [SerializeField] float damageBuff;
    float currentBuff;
    EnemyDamage enemyDamage;

    private void Update()
    {
        //timer running
        timer+=Time.deltaTime;
        if (timer >= spawnRate)
        {

            //randomic spawn and spawn counter update   
            enemyIndex=Random.Range(0,enemy.Length);
            Instantiate(enemy[enemyIndex], transform.position,transform.rotation,transform);
            spawnCounter++;

        
            //if the counter is =10 and spawn rate >=minrate
            if(spawnCounter==10 && spawnRate>=minRate)
            {
                //decrease spawn rate and reset counter
                spawnRate-=changedRate;
                spawnCounter=0;

                //adds buffs 
                currentBuff+=damageBuff;
            }
            
            //timer reset
            timer=0;
        }
    }
}