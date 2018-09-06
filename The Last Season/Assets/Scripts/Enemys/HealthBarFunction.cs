using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HealthBarFunction : MonoBehaviour
{

	private Slider healthBar;
	private int currentHP = 100;

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