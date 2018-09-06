using UnityEngine;
using System.Collections;

public class HealthBarTester : MonoBehaviour
{

	private HealthBarFunction healthBar;

	void Awake()
	{
		healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarFunction>();
	}
	
	void Update ()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			healthBar.changeHP(1);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			healthBar.changeHP(-1);
		}
	}
}