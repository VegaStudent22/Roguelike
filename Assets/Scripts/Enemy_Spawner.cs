using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTimer;
    float currentSpawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpawnTimer < spawnTimer)
        {
            currentSpawnTimer += Time.deltaTime;
        }
        else 
        {
            currentSpawnTimer = 0;
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
