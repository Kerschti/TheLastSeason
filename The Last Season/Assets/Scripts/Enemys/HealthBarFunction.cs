using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HealthBarFunction : MonoBehaviour
{
	// Script für die Gesundheitsanzeige

	//private HealthBarFunction healthBar1;
	
	private Slider healthBar; //hab
	private int currentHP = 100; //hab

	//private HealthBarFunction healthBar;
	
	private void Awake()
	{
		//healthBar = GameObject.Find("HealthBar").GetComponent<HealthBarFunction>();
		healthBar = GetComponent<Slider>();
	}
	
	void Update ()
	{
		healthBar.value = currentHP;
	}

	public void changeHP(int dHP)
	{
		currentHP += dHP;
	}
}