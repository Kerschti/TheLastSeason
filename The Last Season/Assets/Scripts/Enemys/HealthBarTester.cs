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
		if (Input.GetKey(KeyCode.A))
		{
			healthbar.changeHP(10);
		}

		if (Input.GetKey(KeyCode.A))
		{
			healthbar.changeHP(-10);
		}
	}
}