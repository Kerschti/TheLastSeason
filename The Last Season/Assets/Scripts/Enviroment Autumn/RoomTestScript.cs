/*using UnityEngine;
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
		GameObject cube = new  GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.localScale(0.5F, 2.5F, 10);

		cube.transform.position(3, 1.6F, 3);

		// Wand rechts
		GameObject cube2 =  GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube2.transform.localScale(0.5F, 2.5F, 10);

		cube2.transform.position(7.44F, 1.6F, 3);

		
		// Wand Eingang
		GameObject cube3 =  GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube3 = transform.position(5, 1.16F, 8);
		//cube.transform.localRotation(0, 90F, 0);
		cube.transform.localScale(0.5F, 2.5F, 10);
		
		// Wand Ausgang
		GameObject cube4 =  GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position(Vector3(5,  1.16F, -1.78F));
		cube.transform.rotation(Vector3(0, 90F, 0));
		cube.transform.localScale(0.5F, 2.5F, 10);
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(0, 90F, 0);
	}

}
*/