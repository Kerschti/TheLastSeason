using TMPro;
using UnityEngine;
using Unity.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class RoomTestScript : MonoBehaviour
{
	//public RoomTestScript(){}

	//private float breite = 0.0f;
	private float a, b; // xy
	private float wallA, wallB;
	private  Vector3 start = new Vector3(0, 0, 0);
	public GameObject WallPrefab;
	
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
		for (int y = 1; y <= 5; y++)
		{
			Instantiate(WallPrefab, new Vector3(-6.6f, y*0.75f - 0.25f, 0), Quaternion.identity);
		}

		// rotieren Urspung 
		// Abstand von Urspung und Wand
		// Oder a*b dass Spiegeln   --> Wand Prefab erstellen und hochziehen,
/*
		GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube1.transform.localScale = new Vector3(links, breite, hoehe); //xyz

		GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube2.transform.localScale = new Vector3(breite, rechts, hoehe);

*/
/*
		//Vector3 links = new Vector3(Random.Range(5.0f, 12.0f), 0, Random.Range(5.0f, 12.0f));
		//Vector3 rechts = new Vector3(Random.Range(5.0f, 12.0f), 0, Random.Range(5.0f, 12.0f));	

		// Wand links
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		// cube.transform.localScale = new Vector3(x, y, 10);
		cube.transform.localScale = new Vector3(0.5F, 2.5F, 10);
		cube.transform.position = new Vector3(3, 1.6F, 3);

		// Wand rechts
		GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube2.transform.localScale = new Vector3(0.5F, 2.5F, 10);
		cube2.transform.position = new Vector3(7.44F, 1.6F, 3);

		// Wand Eingang
		GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube3.transform.position = new Vector3(5, 1.16F, 8);
		//cube.transform.localRotation = new Vector3(0, 90F, 0);
		cube3.transform.localScale = new Vector3(0.5F, 2.5F, 10);
		cube3.transform.Rotate(new Vector3(0, 90F, 0));

		// Wand Ausgang
		GameObject cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(5, 1.16F, -1.78F);
		cube.transform.rotation = new Vector3(0, 90F, 0);
		cube.transform.localScale = new Vector3(0.5F, 2.5F, 10);
		*/

		/*// Update is called once per frame
		void Update()
		{

		}
*/
	}
}