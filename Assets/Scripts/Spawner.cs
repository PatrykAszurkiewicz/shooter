using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public Transform[] spawnSpots;
    public Transform[] enemySpots;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float timeBtwSpawnsHARD;
    public float timeBtwSpawnsEXTREME;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    private void Update()
    {
        if (Score.scoreValue >= 15 && timeBtwSpawns <= 0)
        {
            int randEnemy = Random.Range(0, enemySpots.Length);
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(enemySpots[randEnemy], spawnSpots[randPos].position, Quaternion.identity);
            if(Score.scoreValue >= 30)
            {
                timeBtwSpawns = timeBtwSpawnsEXTREME;
            }
            else if(Score.scoreValue >= 15)
            {
                timeBtwSpawns = timeBtwSpawnsHARD;
            }
            
        }
        else if (Score.scoreValue >= 5 && timeBtwSpawns <=0)
        {
            int randEnemy = Random.Range(1, enemySpots.Length);
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(enemySpots[randEnemy], spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        
        else if (timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(enemy, spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
            
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }


}
