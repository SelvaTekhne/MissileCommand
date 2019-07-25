﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class City : MonoBehaviour, IDestroyable
{
    public static event Action Destroyed;

    public void Destroy()
    {
        //Debug.Log("-bum!");
        Destroyed?.Invoke();
        Destroy(gameObject);
    }
}
