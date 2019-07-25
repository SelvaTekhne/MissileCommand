﻿using System;
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
    private bool canSpawn = true;
    private bool duringLvl = true;
    private bool isWatingForLvlEnd = false;

   // public static event Action AllRocketsDestroyed;
    public static event Action AllRocketsSpawned;

    void Start()
	{
		EnemyRocket.Destroyed += OnRocketDestroyed;
    }

    private void Update()
    {
        if (duringLvl)
        {
            if(canSpawn)
            {
                RocketRain();
            }
        }
    }

    private void OnRocketDestroyed()
	{
		_numberOfRockets--;
        //Debug.Log("Number of rockets: " + _numberOfRockets);
        if (_numberOfRockets <= 0)
        {
            Debug.Log("All rocket destroyed!");
            //AllRocketsDestroyed?.Invoke();
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
            int rocketsInWave = UnityEngine.Random.Range(1, 4);
            Debug.Log("Rockets in wave: " + rocketsInWave);
            Wave(rocketsInWave);
            totalNumberOfRocketToSpawn -= rocketsInWave;
            Debug.Log("Left rocekts to spawn: " + totalNumberOfRocketToSpawn);

            StartCoroutine(CountingDownToNextWave());

        } else
        if (totalNumberOfRocketToSpawn == 2)
        {
            int rocketsInWave = UnityEngine.Random.Range(1, 3);
            Debug.Log("Rockets in wave: " + rocketsInWave);
            Wave(rocketsInWave);
            totalNumberOfRocketToSpawn -= rocketsInWave;
            Debug.Log("Left rocekts to spawn: " + totalNumberOfRocketToSpawn);

            StartCoroutine(CountingDownToNextWave());

        } else
        if (totalNumberOfRocketToSpawn == 1)
        {
            Wave(totalNumberOfRocketToSpawn);
            Debug.Log("Rockets in wave: " + totalNumberOfRocketToSpawn);
            Wave(totalNumberOfRocketToSpawn);
            totalNumberOfRocketToSpawn--;
            Debug.Log("Left rocekts to spawn: " + totalNumberOfRocketToSpawn);

            StartCoroutine(CountingDownToNextWave());

        } else
        if (totalNumberOfRocketToSpawn == 0)
        {
            Debug.Log("It's all rockets.");
            
            StartCoroutine(CountingDownToEndOfLvl());

            duringLvl = false;
        }
    }

    private void Wave(int numberRocketInWave)
    {
        Vector3 dropPosition;
        for (int i = 0; i < numberRocketInWave; i++)
        {
            dropPosition = new Vector3(UnityEngine.Random.Range(-6f, 6f), 4, 0);

        }
    }

    IEnumerator CountingDownToNextWave()
    {
        canSpawn = false;
        yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(minWaitingTimeForNextWave, maxWaitingTimeForNextWave));
        canSpawn = true;
    }

    IEnumerator CountingDownToEndOfLvl()
    {
        isWatingForLvlEnd = true;
        yield return new WaitForSecondsRealtime(waitingTimeForEndOfLvl);
        Debug.Log("End of lvl!");
        AllRocketsSpawned?.Invoke();
        isWatingForLvlEnd = false;
    }
}
