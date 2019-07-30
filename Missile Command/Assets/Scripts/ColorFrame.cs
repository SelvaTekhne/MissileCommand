using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFrame : MonoBehaviour
{
    public GameObject ground;
    public GameObject lHill;
    public GameObject rHill;
    public GameObject shootingHill;
    public GameObject city;
    public GameObject background;


    void Awake()
    {
        LevelManager.LevelStarted += ColorChanging;
    }

    private void ColorChanging(int lvl)
    {
        switch (lvl)
        {
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }

    }
}
