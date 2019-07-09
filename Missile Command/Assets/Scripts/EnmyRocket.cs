using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmyRocket : MonoBehaviour, IDestroyable
{
	//private bool exist = true;
	public void Destroy(int damage)
	{
		Destroy(gameObject);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
