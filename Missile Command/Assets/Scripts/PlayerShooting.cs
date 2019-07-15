using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	private Vector2 clickPosition;
	private Camera mainCamera;
	//[SerializeField]
	public int numberOfBullets = 10;
	public Vector3 targetPosition;

	public GameObject playerBullet;
	public GameObject shootingStartPoint;
	

	private void Awake()
	{
		mainCamera = Camera.main;
	}

	void Update()
	{
			if (Input.GetMouseButtonDown(0))
			{
				
				clickPosition = Input.mousePosition;
				targetPosition = Input.mousePosition;
				targetPosition.z = 10;
				targetPosition = mainCamera.ScreenToWorldPoint(targetPosition);
				//Debug.Log(targetPosition);

			if (targetPosition.y > shootingStartPoint.transform.position.y)
			{
				if (numberOfBullets > 0)
				{
					Bullet bullet = Instantiate(playerBullet, shootingStartPoint.transform.position, Quaternion.LookRotation(targetPosition)).GetComponent<Bullet>();
					numberOfBullets--;
					bullet.targetPosition = targetPosition;
					//Debug.Log(numberOfBullets);
				}
				else { Debug.Log("You're out of ammo!"); }

			}
			else { Debug.Log("It's too low for shoot!"); }
			}

	}
}


