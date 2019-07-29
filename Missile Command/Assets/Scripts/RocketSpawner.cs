using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketSpawner : MonoBehaviour
{
	public GameObject enemyRocket;
    public GameObject bigBrother;
    public int baseNumberRocketToSpawn = 10;
    public int numberOfRocketToSpawn = 10;
	private int _numberOfRockets = 0;
    //private int _numerOfWaves;
    [SerializeField] private float minWaitingTimeForNextWave = 1;
    [SerializeField] private float maxWaitingTimeForNextWave = 3;
    [SerializeField] private float waitingTimeForEndOfLvl = 15;
    [SerializeField] private float chanceForBB = 10f;
    public GameObject screenOfEndLvl;
    public GameObject screenGameOver;
    public GameObject unless;
    public GameObject protect;
    private bool canSpawn = true;
    private bool duringLvl = false;
    private bool isWatingForLvlEnd = false;
    private bool isGameOver = false;

   // public static event Action AllRocketsDestroyed;
    public static event Action AllRocketsSpawned;
    public static event Action GameOver;

    void Awake()
	{
		EnemyRocket.Destroyed += OnRocketDestroyed;
        LevelManager.LevelStarted += StartSpawning;
        CitiesController.AllCitiesDestroyed += Apocalypse;
    }

    private void OnDestroy()
    {
        LevelManager.LevelStarted -= StartSpawning;
        EnemyRocket.Destroyed -= OnRocketDestroyed;
        CitiesController.AllCitiesDestroyed -= Apocalypse;
    }

    void StartSpawning(int lvl)
    {
        duringLvl = true;
        numberOfRocketToSpawn = (int)(baseNumberRocketToSpawn + 3f * lvl);
        chanceForBB = chanceForBB + 2f * lvl;
        waitingTimeForEndOfLvl = waitingTimeForEndOfLvl - 0.2f * LevelManager.Level;

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

    public void Apocalypse()
    {
        isGameOver = true;
    }
    
    void RocketRain()
    {       
        if (numberOfRocketToSpawn >= 3)
        {
            int rocketsInWave = UnityEngine.Random.Range(1, 4);
            Debug.Log("Rockets in wave: " + rocketsInWave);

            if (rocketsInWave >= 3)
            {
                float randomBB = UnityEngine.Random.Range(0, 101);
                Debug.LogError("Chance for BB: " + randomBB);

                if (randomBB <= chanceForBB)
                {
                    Instantiate(bigBrother, new Vector3(UnityEngine.Random.Range(-6f, 6f), 4, 0), this.transform.rotation);
                }
                else
                {
                    Wave(rocketsInWave);
                }
            }
            else
            {
                Wave(rocketsInWave);
            }

            numberOfRocketToSpawn -= rocketsInWave;
            Debug.Log("Left rocekts to spawn: " + numberOfRocketToSpawn);

            StartCoroutine(CountingDownToNextWave());

        } else
        if (numberOfRocketToSpawn == 2)
        {
            int rocketsInWave = UnityEngine.Random.Range(1, 3);
            Debug.Log("Rockets in wave: " + rocketsInWave);
            Wave(rocketsInWave);
            numberOfRocketToSpawn -= rocketsInWave;
            Debug.Log("Left rocekts to spawn: " + numberOfRocketToSpawn);

            StartCoroutine(CountingDownToNextWave());

        } else
        if (numberOfRocketToSpawn == 1)
        {
            Wave(numberOfRocketToSpawn);
            Debug.Log("Rockets in wave: " + numberOfRocketToSpawn);
            Wave(numberOfRocketToSpawn);
            numberOfRocketToSpawn--;
            Debug.Log("Left rocekts to spawn: " + numberOfRocketToSpawn);

            StartCoroutine(CountingDownToNextWave());

        } else
        if (numberOfRocketToSpawn == 0)
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
        screenOfEndLvl.SetActive(true);
        Debug.Log("End of lvl!");
        AllRocketsSpawned?.Invoke();
        isWatingForLvlEnd = false;
        if (!isGameOver)
        {
            yield return new WaitForSecondsRealtime(5);
            screenOfEndLvl.SetActive(false);
            LevelManager.Instance.StartNewLevel();
        }
        else
        {
            unless.SetActive(true);
            yield return new WaitForSecondsRealtime(3);
            screenOfEndLvl.SetActive(false);
            yield return new WaitForSecondsRealtime(2);
            screenGameOver.SetActive(true);
            yield return new WaitForSecondsRealtime(1);
            unless.SetActive(false);
            yield return new WaitForSecondsRealtime(4);
            screenGameOver.SetActive(false);
            yield return new WaitForSecondsRealtime(2);

            GameOver?.Invoke();
                       
            SceneManager.LoadScene(0);
        }
        
    }
}
