using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	private Vector2 clickPosition;
	private Camera mainCamera;
    //public int numberOfBulletsInLoad = 10; //tu czekają rozgrzebane do zrobienia 3x10 poscisków
    // public int numberOfLoads = 3;

    public int totalNumberOfBullets;
    public int actualNumberOfBullets;
    public static event Action Reload;
	public Vector3 targetPosition;

	public GameObject playerBullet;
	public GameObject shootingStartPoint;
    private bool isGameOver = false;


    private void Awake()
	{
		mainCamera = Camera.main;
        LevelManager.LevelStarted += SetBullets;
        CitiesController.AllCitiesDestroyed += Apocalypse;
        //totalNumberOfBullets = numberOfBulletsInLoad * numberOfLoads;
	}

    private void OnDestroy()
    {
        LevelManager.LevelStarted -= SetBullets;
        CitiesController.AllCitiesDestroyed -= Apocalypse;
    }

    public void SetBullets(int lvl)
    {
        actualNumberOfBullets = totalNumberOfBullets;
    }

    public void Apocalypse()
    {
        isGameOver = true;
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
				    if (actualNumberOfBullets > 0)
				    {
					    Bullet bullet = Instantiate(playerBullet, shootingStartPoint.transform.position, Quaternion.LookRotation(targetPosition)).GetComponent<Bullet>();
                        actualNumberOfBullets--;
					    bullet.targetPosition = targetPosition;
					    //Debug.Log(numberOfBullets);
				    }
				    else { Debug.Log("You're out of ammo!"); }

			    }
			    else { Debug.Log("It's too low for shoot!"); }
			}

	}

    void Reloading()
    {

    }
}


