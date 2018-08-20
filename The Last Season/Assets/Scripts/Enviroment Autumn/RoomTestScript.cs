using TMPro;
using UnityEngine;
using Unity.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class RoomTestScript : MonoBehaviour
{

	private float a, b; // xy

	float segHoehe = 13.0f;
	float segTiefe = 1.0f;
	
	
	
	public void Zufall()
	{
		for (int i = 1; i <= 10; i++)
		{
			a = Random.Range(5.0f, 12.0f);
		}

		for (int i = 1; i <= 10; i++)
		{
			b = Random.Range(5.0f, 12.0f);
		}
	}

	// Instanz von Prefabs Wall
	public void createWall()
	{
		// Hier Rechteck a*b und dann Spiegelen die -a*-b
	
	}


	void Start()
	{
		
	}
}