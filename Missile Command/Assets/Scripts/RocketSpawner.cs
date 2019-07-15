using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
	public GameObject enemyRocket;
	public int totalNumberOfRocketsToSpawn = 10;
    public int maxNumberOfRocketsInWave = 2;
    private int _numberOfRockets = 0;
    private int _totalNumberOfSpawnedRockets = 0;
    public float waveDuration = 3;
    private bool isItAllRockets = false;

    public static event Action AllRocketsDestroyed;
    WaitForSeconds waiting;

	void Start()
	{
        EnemyRocket.Destroyed += OnRocketDestroyed;
        waiting = new WaitForSeconds(waveDuration);

        StartCoroutine(SpawningRockets());

    }

    IEnumerator SpawningRockets()
    {
        while (_totalNumberOfSpawnedRockets < totalNumberOfRocketsToSpawn)
        {
            WaveSpawning();
            yield return waiting;
        }
        isItAllRockets = true;
    }

    private void WaveSpawning()
    {
        for (int i = 0; i < maxNumberOfRocketsInWave; i++)
        {
            //Dodać sprawdzanie czy nie przekroczyliśmy total i randomizowanie liczby ralkiet
            Vector3 dropPosition = new Vector3(UnityEngine.Random.Range(-6f, 6f), 4, 0);
            Instantiate(enemyRocket, dropPosition, Quaternion.identity);
            _numberOfRockets++;
            _totalNumberOfSpawnedRockets++;
        }
    }

    private void OnRocketDestroyed()
    {
        _numberOfRockets--;
        if(_numberOfRockets <= 0 && isItAllRockets)
        {
            AllRocketsDestroyed?.Invoke();
        }
    }

    private void OnDestroy()
    {
        EnemyRocket.Destroyed -= OnRocketDestroyed;
    }
}
