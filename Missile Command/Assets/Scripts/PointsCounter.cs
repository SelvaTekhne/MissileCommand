using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    private static PointsCounter _instance;
    public static PointsCounter Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new PointsCounter();
            }
            return _instance;
        }
    }

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
	[SerializeField]private Text _counter;

    private int _points = 0;

	void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this);
        EnemyRocket.Destroyed += EnemyRocketDestroyed;
	}

    public void EnemyRocketDestroyed()
    {
        _points++;
        Counter.text = _points.ToString();
    }

    private void OnDestroy()
    {
        EnemyRocket.Destroyed -= EnemyRocketDestroyed;
    }
}
