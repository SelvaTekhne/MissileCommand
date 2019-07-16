using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
	public GameObject enemyRocket;
	public int totalNumberOfRocketToSpawn = 10;
	private int _numberOfRockets = 0;

	public static event Action AllRocketsDestroyed;
	
	void Start()
	{
		EnemyRocket.Destroyed += OnRocketDestroyed;
		for (int i = 0; i < totalNumberOfRocketToSpawn; i++)
		{
			Vector3 dropPosition = new Vector3(UnityEngine.Random.Range(-6f, 6f), 4, 0);
			Instantiate(enemyRocket, dropPosition, Quaternion.identity);
			_numberOfRockets++;
		}
	}

	private void OnRocketDestroyed()
	{
		_numberOfRockets--;
		if(_numberOfRockets <= 0)
		{
			AllRocketsDestroyed?.Invoke();
		}
	}

	private void OnDestroy()
	{
		EnemyRocket.Destroyed -= OnRocketDestroyed;
	}
}
