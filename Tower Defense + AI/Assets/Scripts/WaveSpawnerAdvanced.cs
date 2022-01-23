using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerAdvanced : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
        public Transform spawnPoint;
        public float healthMultiplier;
        public float speed;
    }

    public Wave[] waves;
    private int waveIndex = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;

    public Text waveCountdownText;
    public Text waveNumber;

    void Start()
    {
        waveCountDown = timeBetweenWaves;
        waveNumber.text = 1.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
			if (!EnemyIsAlive())
			{
                WaveCompleted();
			}
			else
			{
                return;
			}
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[waveIndex]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }

        waveCountdownText.text = Mathf.Round(waveCountDown).ToString();
    }

    void WaveCompleted()
	{
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (waveIndex + 1 > waves.Length - 1)
        {
            waveIndex = 0;
            waveNumber.text = (waveIndex + 1).ToString();
            Debug.Log("All waves are completed!");
        }
		else
		{
            waveIndex++;
            waveNumber.text = (waveIndex + 1).ToString();
        }
	}

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
	}

    IEnumerator SpawnWave(Wave _wave) 
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
		{
            SpawnEnemy(_wave.enemy, _wave.spawnPoint, _wave.healthMultiplier, _wave.speed);
            yield return new WaitForSeconds(1f / _wave.rate);
		}

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _enemy, Transform spawnPoint, float _healthMultiplier, float _speed)
	{
        Debug.Log("Spawning Enemy: " + _enemy.name);
        GameObject enemy = (GameObject)Instantiate(_enemy.gameObject, spawnPoint.position, spawnPoint.rotation);
        Enemy_Health health = enemy.GetComponent<Enemy_Health>();
        EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
        health.SetHealth(_healthMultiplier);
        movement.SetSpeed(_speed);

    }
}
