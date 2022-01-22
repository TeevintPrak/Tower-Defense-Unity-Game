using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefabs;
    public string name;
    public float timeBetweenWaves = 5f;
    public float countdown = 2f;

    void Update()
    {
        if(countdown <= 0f)
		{
            SpawnWave();
            countdown = timeBetweenWaves;
		}

        countdown -= Time.deltaTime;
    }

    void SpawnWave() 
    {
        Debug.Log("Wave Incoming!");
    }
}
