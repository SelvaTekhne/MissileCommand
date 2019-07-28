using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
	public GameObject enemyRocket;
    public GameObject bigBrother;
    public int totalNumberOfRocketToSpawn = 10;
	private int _numberOfRockets = 0;
    //private int _numerOfWaves;
    [SerializeField] private float minWaitingTimeForNextWave = 1;
    [SerializeField] private float maxWaitingTimeForNextWave = 3;
    [SerializeField] private float waitingTimeForEndOfLvl = 15;
    [SerializeField] private float chanceForBigBrother = 0.1f;
    private bool canSpawn = true;
    private bool duringLvl = true;
    private bool isWatingForLvlEnd = false;

   // public static event Action AllRocketsDestroyed;
    public static event Action AllRocketsSpawned;

    void Start()
	{
		EnemyRocket.Destroyed += OnRocketDestroyed;
        Instantiate(bigBrother, new Vector3(UnityEngine.Random.Range(-6f, 6f), 4, 0), this.transform.rotation);
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
        var positionsList = new List<Vector3>();
        float minPosition;
        float maxPosition;
        float minAngle;
        float maxAngle;
        float finalAngle;

        for (int i = 0; i < numberRocketInWave; i++)
        {
            float x = UnityEngine.Random.Range(-6f, 6f);

            if (i > 0)
            {
                while (Mathf.Abs(x - positionsList[i - 1].x) < 1.3)
                {
                    x = UnityEngine.Random.Range(-6f, 6f);
                }
            }
            positionsList.Add(new Vector3(x, 4, 0));
            Debug.Log("Now postition: " + positionsList[i].x);
        }
        maxPosition = positionsList.Max(vector3 => vector3.x);
        minPosition = positionsList.Min(vector3 => vector3.x);
        Debug.Log("Mini: " + minPosition + ", max: " + maxPosition + " positions.");

        minAngle = Mathf.Atan2(-6f - minPosition, -8.8f) * 2 * Mathf.PI;
        maxAngle = Mathf.Atan2(6f - maxPosition, -8.8f) * 2 * Mathf.PI;
        Debug.Log("Mini: " + minAngle + ", max: " + maxAngle + " angles.");

        finalAngle = UnityEngine.Random.Range(minAngle, maxAngle);
        Debug.Log("Final angle: " + finalAngle);

        Quaternion spawnRotation = this.transform.rotation * Quaternion.Euler(0, finalAngle, 0);

        foreach (Vector3 position in positionsList)
        {
            Vector3 dropPosition = position;
            Instantiate(enemyRocket, dropPosition, spawnRotation);
            _numberOfRockets++;
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
