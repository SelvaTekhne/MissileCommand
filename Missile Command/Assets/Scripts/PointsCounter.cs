using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
	private static PointsCounter _instance;
	public static PointsCounter Instance;
	[SerializeField] private Text _counter;
    [SerializeField] private Text _highScore;
    [SerializeField] private GameObject cities;
    private int _savedCities;

	private Text Counter
	{
		get
		{
			if(_counter == null)
			{
				_counter = gameObject.GetComponent<Text>();
			}
			return _counter;
		}
	}

   private Text HighScore
    {
        get
        {
            if (_highScore == null)
            {
                _highScore = gameObject.GetComponent<Text>();
            }
            return _highScore;
        }
    }
    private int _points = 0;

	[SerializeField] private int _destroyedRocketMultiplier;
	[SerializeField] private int _remainedBulletMultiplier;
    [SerializeField] private int _savedCityMultiplier;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this);
		}
		else
		{
			_instance = this;
			DontDestroyOnLoad(this);
            HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            EnemyRocket.Destroyed += EnemyRocketDestroyed;
            RocketSpawner.AllRocketsSpawned += CitySaved;
            CitiesController.AllCitiesDestroyed += CheckHighScore;
            Counter.text = _points.ToString();
        }
        
	}

	public void EnemyRocketDestroyed()
	{
		_points += _destroyedRocketMultiplier;

		Counter.text = _points.ToString();
	}

    public void CheckHighScore()
    {
        Debug.LogError("There's high score update.");
            HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            HighScore.text = 5.ToString();
            if (_points > PlayerPrefs.GetInt("HighScore", 0))
            {
                HighScore.text = 7.ToString();
                PlayerPrefs.SetInt("HighScore", _points);
                    HighScore.text = _points.ToString();
                Debug.LogError("Score update success.");
            }

        CitiesController.AllCitiesDestroyed -= CheckHighScore;
    }
    
    public void CitySaved()
    {
        Debug.Log("Counting saved cities...");

        _savedCities = cities.GetComponent<CitiesController>().actualNumberOfCities;

        Debug.Log(_savedCities * _savedCityMultiplier);
        _points += (_savedCities * _savedCityMultiplier);

        Counter.text = _points.ToString();
    }

    private void OnDestroy()
	{
		EnemyRocket.Destroyed -= EnemyRocketDestroyed;
    }

}
