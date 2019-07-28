using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
	public SphereCollider colliderExplosion;
	
	//Dobrze by było podłączyć tu jeszcze sterowanie animacją particli, ale to może później.
	[SerializeField] private float speedOfSpreading = 1;
	[SerializeField] private float startRange = 1;
	[SerializeField] private float maxRange = 1;
	
	void Awake()
    {
		//Debug.Log("Boom!");
		//colliderExplosion = gameObject.AddComponent<SphereCollider>();
		colliderExplosion.isTrigger = true;
		colliderExplosion.radius = startRange;
	}
	
    void Update()
    {
		if (colliderExplosion.radius <= maxRange)
		{
			float step = speedOfSpreading * Time.deltaTime;
			colliderExplosion.radius += step;
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		IDestroyable destroyable = other.transform.root.GetComponentInChildren<IDestroyable>();
		if(destroyable != null)
		{
			destroyable.Destroy();
		}
	}

}
