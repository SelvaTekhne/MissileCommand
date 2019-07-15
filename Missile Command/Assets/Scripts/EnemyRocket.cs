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


    /*void Start()
    {
        
    }
	
    void Update()
    {

	}*/

    /*void OnTriggerEnter(Collider other)
	{
		//if (other.name == "ExplosionEffect")
		//{
			Debug.Log("Bang!");
			Destroy(gameObject);
		//DestroyedByPlayer();
		//}

	}*/



    /*void DestroyedByPlayer()
	{
		rocketCounter++; //jeszcze nie działa
						 //Destroy(gameObject);
		Debug.Log($"You shot down {rocketCounter} rockets");
		Destroy(gameObject);

	}

	void ExplodedToTheGround(bool damage)
	{
		Destroy(gameObject);
	}*/

    /*int OnDestroy(PointsCounter.)
	{
		return rocketCounter = rocketCounter + rocketPoints;
	}*/
}
