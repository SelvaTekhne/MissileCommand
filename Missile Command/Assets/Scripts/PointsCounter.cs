using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
	public EnmyRocket enmyRocket;
	private Text counter;

	void Start()
    {
		counter = gameObject.GetComponent<Text>();
		counter.text = enmyRocket.rocketCounter.ToString();
	}

    void Update()
    {
		counter.text = enmyRocket.rocketCounter.ToString();
	}
}
