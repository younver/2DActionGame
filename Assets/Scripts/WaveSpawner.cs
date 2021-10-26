using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] Enemies;
        public int count;
        public float TimeBetweenSpawns;
    }

    public Wave[] Waves;
    public Transform[] SpawnPoints;
    public float TimeBetweenWaves;

    private Wave _currentWave;
    private Transform _player;
    private int _currentWaveIndex;
    private bool _isFinishedSpawning = false;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(_currentWaveIndex));
    }

    private void Update()
    {
        if (_isFinishedSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            _isFinishedSpawning = false;

            if (_currentWaveIndex + 1 < Waves.Length)
            {
                _currentWaveIndex++;
                StartCoroutine(StartNextWave(_currentWaveIndex));
            }
            else
            {
                Debug.Log("No more waves in hell!");
            }
        }
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(TimeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        _currentWave = Waves[index];

        for (int i = 0; i < _currentWave.count; i++)    
        {
            if (_player == null) yield break;

            Enemy randomEnemy = _currentWave.Enemies[Random.Range(0, _currentWave.Enemies.Length)];
            Transform randomPosition = SpawnPoints[Random.Range(0, SpawnPoints.Length)];

            Instantiate(randomEnemy, randomPosition.position, randomPosition.rotation);

            if(i == _currentWave.count - 1) _isFinishedSpawning = true;

            yield return new WaitForSeconds(_currentWave.TimeBetweenSpawns);
        }
    }
}
