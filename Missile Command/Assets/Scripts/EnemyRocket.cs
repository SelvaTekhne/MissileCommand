using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyRocket : MonoBehaviour, IDestroyable
{
    public static event Action Destroyed;

    public void Destroy()
    {
        Debug.Log("Bang!");
        Destroyed?.Invoke();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Łup-");
        if (collision.gameObject.tag == "City")
        {
           // Debug.Log("-du-");
            IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
            if (destroyable != null)
            {
                destroyable.Destroy();
            }
        }
        Destroy(gameObject);
    }
}
    