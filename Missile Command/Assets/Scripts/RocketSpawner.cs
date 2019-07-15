using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
	public GameObject enmyRocket;
	public int numberOfRocket = 10;
	
	void Start()
	{
		for (int i = 0; i <= numberOfRocket; i++)
		{
			Vector3 dropPosition = new Vector3(UnityEngine.Random.Range(-6f, 6f), 4, 0);
			Instantiate(enmyRocket, dropPosition, Quaternion.identity);
		}
	}
}
