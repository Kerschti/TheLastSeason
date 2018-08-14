using UnityEngine;
using Unity.Collections;
using UnityEngine.SceneManagement;

public class RoomTestScript : MonoBehaviour
{
	//private GameObject wall;
	public int left, right, top, bot;

	public RoomTestScript()
	{

	}

	// Use this for initialization
	void Start()
	{

		// Wand links
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.localScale = new Vector3(0.5F, 2.5F, 10);

		cube.transform.position = new Vector3(3, 1.6F, 3);

		// Wand rechts
		GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube2.transform.localScale = new Vector3(0.5F, 2.5F, 10);

		cube2.transform.position = new Vector3(7.44F, 1.6F, 3);
/*
		
		// Wand Eingang
		GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(5, 1.16F, 8);
		cube.transform.localRotation = new Vector3(0, 90F, 0);
		cube.transform.localScale = new Vector3(0.5F, 2.5F, 10);
		
		// Wand Ausgang
		GameObject cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(5,  1.16F, -1.78F);
		cube.transform.rotation = new Vector3(0, 90F, 0);
		cube.transform.localScale = new Vector3(0.5F, 2.5F, 10);
	}*/

		// Update is called once per frame
		/*void Update()
		{

		}*/
	}
}
