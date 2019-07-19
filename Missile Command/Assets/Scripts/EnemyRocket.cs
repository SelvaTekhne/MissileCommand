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

    private void OnTriggerEnter(Collider other)
    {
        if(Collider.)
        {
            IDestroyable destroyable = city.GetComponent<IDestroyable>();
            if (destroyable != null)
            {
                destroyable.Destroy();
            }
        }
    }
}
