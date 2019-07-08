using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public Vector2 clickPosition;
	void Update()
	{
		

		if (Input.GetMouseButtonDown(0))
		{
			clickPosition = Input.mousePosition;
			Debug.Log("Pressed primary button.");
			Debug.Log(clickPosition);
			/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray))
				Instantiate(particle, transform.position, transform.rotation); */
		}
	}
}