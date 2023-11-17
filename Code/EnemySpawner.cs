using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;

    public Transform topBorder;
    public Transform bottomBorder;
    
    public static int spawnCounter = 10;
    public int spawnAddPerLevel = 5;
    public float spawnInterval = 1f;
    public float spawnTimer = 0f;
    void Start()
    {
        spawnCounter += spawnAddPerLevel * LevelController.level;
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelController.finished == false)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else if (spawnCounter > 0)
            {
                Spawn();
                spawnTimer = Random.Range(spawnInterval-1,spawnInterval+1);
            }
        }
    }
    public void Spawn() {
        spawnCounter--;
 
        Vector2 randomPosition = new Vector2(transform.position.x, Random.Range(bottomBorder.position.y, topBorder.position.y));
 
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
 
    }
}
