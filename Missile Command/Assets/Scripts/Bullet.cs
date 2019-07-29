using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Vector3 targetPosition;

	[SerializeField] private float speed = 1;
	[SerializeField] private GameObject explosionEffect;
    [SerializeField] private ParticleSystem particleTrail;
 
	void Update()
    {
		float step = speed * Time.deltaTime;
		this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, step);

		if (Vector3.Distance(this.transform.position, targetPosition) <= Mathf.Epsilon)
		{
			Instantiate(explosionEffect, this.transform.position, Quaternion.identity);
            particleTrail.transform.parent = null;
            Destroy(particleTrail.gameObject, 13);
            Destroy(this.gameObject);
            //Instantiate
            //Destroy(explosionEffect.gameObject);
        }
	}

    private void OnDestroy()
    {
    }
}
