using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CitiesController : MonoBehaviour
{
    public GameObject city;
    public List<Transform> citiesSpawnPositions;
    int totalNumberOfCities = 0;
    public int actualNumberOfCities;
    public static event Action AllCitiesDestroyed;


    private void Awake()
    {
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
