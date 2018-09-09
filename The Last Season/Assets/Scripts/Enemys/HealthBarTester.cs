using UnityEngine;
using System.Collections;

public class HealthBarTester : MonoBehaviour
{

	private HealthBarFunction healthbar;

	void Awake()
	{
		healthbar = GameObject.Find("HealthBar").GetComponent<HealthBarFunction>();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			healthbar.changeHP(10);
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			healthbar.changeHP(-10);
		}
	}
}