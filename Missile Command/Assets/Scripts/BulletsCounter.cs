using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsCounter : MonoBehaviour
{
	public PlayerShooting playerShooting;
	private Text counter;
	
    void Start()
    {
		counter = gameObject.GetComponent<Text>();
		counter.text = playerShooting.actualNumberOfBullets.ToString();
    }
	
    void Update()
	{
		counter.text = playerShooting.actualNumberOfBullets.ToString();
	}
}
