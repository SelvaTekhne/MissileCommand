using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmyRocket : MonoBehaviour
{
	public int rocketCounter;
	public int rocketPoints;

	void Start()
    {
        
    }
	
    void Update()
    {

	}

	void OnTriggerEnter(Collider other)
	{
		//if (other.name == "ExplosionEffect")
		//{
			Debug.Log("Bang!");
			Destroy(gameObject);
		//DestroyedByPlayer();
		//}

	}

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
