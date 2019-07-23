using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
	private static PointsCounter _instance;
	public static PointsCounter Instance;
	[SerializeField] private Text _counter;
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
			EnemyRocket.Destroyed += EnemyRocketDestroyed;
            RocketSpawner.AllRocketsDestroyed += CitySaved;
		}
	}

	public void EnemyRocketDestroyed()
	{
		_points += _destroyedRocketMultiplier;

		Counter.text = _points.ToString();
	}


    
    public void CitySaved()
    {
        Debug.Log("Counting saved cities...");

        //_points += _savedCityMultiplier;

        //Counter.text = _points.ToString();
    }

    private void OnDestroy()
	{
		EnemyRocket.Destroyed -= EnemyRocketDestroyed;
    }

}
