using System;
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
    [SerializeField] public float damageBuff;




    private void Update()
    {
        //timer running
        timer+=Time.deltaTime;
        if (timer >= spawnRate)
        {

            //randomic spawn and spawn counter update   
            enemyIndex=UnityEngine.Random.Range(0,enemy.Length);
            GameObject newEnemy=Instantiate(enemy[enemyIndex], transform.position,transform.rotation,transform);
            EnemyDamage newDamage=newEnemy.GetComponent<EnemyDamage>();
            spawnCounter++;

            if (newDamage != null)
            {
                newDamage.SetAttack(damageBuff);
            }

        
            //if the counter is =10 and spawn rate >=minrate
            if(spawnCounter==10)
            {
                if(spawnRate>minRate)
                    //decrease spawn rate
                    spawnRate-=changedRate;

                //resets spawn counter
                spawnCounter=0;
                //adds DMG buffs 
                damageBuff++;
            }
            
            //timer reset
            timer=0;
        }
    }
}