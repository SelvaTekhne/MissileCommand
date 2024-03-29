﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CitiesController : MonoBehaviour
{
    public GameObject city;
    public List<Transform> citiesSpawnPositions;
    int totalNumberOfCities;
    public int actualNumberOfCities;
    public static event Action AllCitiesDestroyed;
    //private static CitiesController _instance;
    //public static CitiesController Instance;


    private void Awake()
    {
        /*if (_instance != null && _instance != this)
        {
            //Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }*/

        foreach (Transform cityTransform in citiesSpawnPositions)
        {
            Vector3 cityPosition = cityTransform.position;
            Instantiate(city, cityPosition, Quaternion.identity);
            totalNumberOfCities++;
        }
        actualNumberOfCities = totalNumberOfCities;
        Debug.Log("Number of cities: " + totalNumberOfCities);

        City.Destroyed += DestroyTheCity;

    }

    private void OnDestroy()
    {
        City.Destroyed -= DestroyTheCity;
    }

    private void Update()
    {
        
    }

    public void DestroyTheCity()
    {
        actualNumberOfCities--;
        Debug.Log("Actual number of cities: " + actualNumberOfCities);
        if (actualNumberOfCities <= 0)
        {
            AllCitiesDestroyed?.Invoke();
            Debug.Log("Game Over!");
        }
    }
}
