using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class City : MonoBehaviour, IDestroyable
{
    public static event Action Destroyed;
    public GameObject nuke;
    public AudioSource explosionSound;

    public void Destroy()
    {
        //Debug.Log("-bum!");
        Instantiate(nuke, transform.position + new Vector3(0,1,0), Quaternion.identity);
        explosionSound.volume = 0.6f;
        explosionSound.spatialBlend = 1f;
        explosionSound.Play();

        Destroyed?.Invoke();
        Destroy(gameObject);
    }
}
