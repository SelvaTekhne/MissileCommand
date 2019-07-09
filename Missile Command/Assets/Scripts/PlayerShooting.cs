using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	private Vector2 clickPosition;
	private Camera mainCamera;
	//[SerializeField]
	public int numberOfBullets;

	public GameObject bullet;
	public GameObject shootingStartPoint;
	

	private void Awake()
	{
		mainCamera = Camera.main;
	}

	void Update()
	{
			if (Input.GetMouseButtonDown(0))
			{
			if (numberOfBullets > 0)
			{
				clickPosition = Input.mousePosition;
				var targetPosition = Input.mousePosition;
				targetPosition.z = 10;
				targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);
				Debug.Log(targetPosition);

				Instantiate(bullet, shootingStartPoint.transform.position, Quaternion.LookRotation(targetPosition));
				numberOfBullets--;
				//Debug.Log(numberOfBullets);
			}
			else Debug.Log("You're out of ammo!");
		}

	}
}


