/*using System;
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


    public static event Action AllRocketsDestroyed;
    public static event Action AllRocketsSpawned;

    void Start()
	{
		EnemyRocket.Destroyed += OnRocketDestroyed;       
    }

    private void Update()
    {
        RocketRain();
    }

    private void OnRocketDestroyed()
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
            Wave(rocketsInWave);
            totalNumberOfRocketToSpawn -= rocketsInWave;
            Debug.Log("Left rocekts to spawn: " + totalNumberOfRocketToSpawn);

            StartCoroutine(CountingDownToNextWave());

        } else
        if (totalNumberOfRocketToSpawn == 2)
        {
            int rocketsInWave = UnityEngine.Random.Range(1, 2);
            Debug.Log("Rockets in wave: " + rocketsInWave);
            Wave(rocketsInWave);
            totalNumberOfRocketToSpawn -= rocketsInWave;
            Debug.Log("Left rocekts to spawn: " + totalNumberOfRocketToSpawn);

            StartCoroutine(CountingDownToNextWave());

        } else
        if (totalNumberOfRocketToSpawn == 1)
        {
            Wave(totalNumberOfRocketToSpawn);
            Debug.Log("It's all rockets.");
            
            StartCoroutine(CountingDownToEndOfLvl());

            AllRocketsSpawned?.Invoke();
        }
    }

    private void Wave(int numberRocketInWave)
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
}*/
