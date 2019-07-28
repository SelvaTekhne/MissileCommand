using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private int lvl = 0;
    public static int Level
    {
        get
        {
            return Instance.lvl;
        }
    }
    public static event Action<int> LevelStarted; 

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        StartNewLevel();
    
    }

    public void StartNewLevel()
    {
        lvl++;
        LevelStarted?.Invoke(lvl);
    }
}
