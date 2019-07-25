﻿/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
	public GameObject enemyRocket;
	public int totalNumberOfRocketToSpawn = 10;
	private int _numberOfRockets = 0;
    //private int _numerOfWaves;
    [SerializeField] private float minWaitingTimeForNextWave = 1;
    [SerializeField] private float maxWaitingTimeForNextWave = 3;
    [SerializeField] private float waitingTimeForEndOfLvl = 15;

    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    
    [System.Serializable]
    public class Wave
    {
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    public SpawnState state = SpawnState.COUNTING;


    //public static event Action AllRocketsDestroyed;
    //public static event Action AllRocketsSpawned;

    void Start()
	{
        //EnemyRocket.Destroyed += OnRocketDestroyed;       
        waveCountDown = timeBetweenWaves;
    }

    private void Update()
    {
        //RocketRain();
        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                // Start spawning wave
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }

        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        yield break;
    }

    /*private void OnRocketDestroyed()
	{
		_numberOfRockets--;
        Debug.Log("Number of rockets: " + _numberOfRockets);
        if (_numberOfRockets <= 0)
        {
            Debug.Log("All rocket destroyed!");
            AllRocketsDestroyed?.Invoke();
		}
	}

	private void OnDestroy()
	{
		EnemyRocket.Destroyed -= OnRocketDestroyed;
	}

    void RocketRain()
    {       
        if (totalNumberOfRocketToSpawn >= 3)
        {
            int rocketsInWave = UnityEngine.Random.Range(1, 3);
            Debug.Log("Rockets in wave: " + rocketsInWave);
            RelaseWave(rocketsInWave);
            totalNumberOfRocketToSpawn -= rocketsInWave;
            Debug.Log("Left rocekts to spawn: " + totalNumberOfRocketToSpawn);

            StartCoroutine(CountingDownToNextWave());

        } else
        if (totalNumberOfRocketToSpawn == 2)
        {
            int rocketsInWave = UnityEngine.Random.Range(1, 2);
            Debug.Log("Rockets in wave: " + rocketsInWave);
            RelaseWave(rocketsInWave);
            totalNumberOfRocketToSpawn -= rocketsInWave;
            Debug.Log("Left rocekts to spawn: " + totalNumberOfRocketToSpawn);

            StartCoroutine(CountingDownToNextWave());

        } else
        if (totalNumberOfRocketToSpawn == 1)
        {
            RelaseWave(totalNumberOfRocketToSpawn);
            Debug.Log("It's all rockets.");
            
            StartCoroutine(CountingDownToEndOfLvl());

            AllRocketsSpawned?.Invoke();
        }
    }

    private void RelaseWave(int numberRocketInWave)
    {
        for (int i = 0; i < numberRocketInWave; i++)
        {
            Vector3 dropPosition = new Vector3(UnityEngine.Random.Range(-6f, 6f), 4, 0);
            Instantiate(enemyRocket, dropPosition, Quaternion.identity);
            _numberOfRockets++;
        }
    }

    IEnumerator CountingDownToNextWave()
    {
        yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(minWaitingTimeForNextWave, maxWaitingTimeForNextWave));
    }

    IEnumerator CountingDownToEndOfLvl()
    {
        yield return new WaitForSecondsRealtime(waitingTimeForEndOfLvl);
    }
}
*/