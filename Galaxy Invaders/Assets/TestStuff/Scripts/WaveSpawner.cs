using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState{SPAWNING, WAITING, COUNTING}

    public Wave[] waves;
    public Transform[] spawnPoints;

    private int nextWave = 0;

    public float timeBetweenWaves= 5f;
    private float waveCountdown;

    public float searchCountdown = 1f;
    public bool enableWaves;

    private SpawnState state = SpawnState.COUNTING;

	// Use this for initialization
	void Start () {
        waveCountdown = timeBetweenWaves;
	}
	
	// Update is called once per frame
	void Update () {
        if (enableWaves)
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

            if (waveCountdown <= 0)
            {
                if (state != SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
	}

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null) {
                Debug.Log("Wave completed");
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("spawning wave:" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[ Random.Range( 0, spawnPoints.Length) ];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        Debug.Log("spawning enemy: " + _enemy.name);
    }

    void WaveCompleted() {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) nextWave = 0;
        else nextWave++;
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
}
