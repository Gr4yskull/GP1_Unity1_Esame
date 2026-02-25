using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy; 
    [SerializeField] float spawnRate; 
    float timer;
    int enemyIndex;
    int spawnCounter=0;
    [SerializeField] float minRate;
    [SerializeField] float changedRate;

    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer >= spawnRate)
        {
            
            enemyIndex=Random.Range(0,enemy.Length);
            Instantiate(enemy[enemyIndex], transform.position,transform.rotation,transform);
            spawnCounter++;

        
            if(spawnCounter==10 && spawnRate>=minRate)
            {
                spawnRate-=changedRate;
            }
            
            timer=0;
        }
    }
}