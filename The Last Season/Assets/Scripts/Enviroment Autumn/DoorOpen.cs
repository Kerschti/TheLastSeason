using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
	public GameObject guiObject;
	//public GameObject player;
	
	public string levelToLoad;
	
	// Use this for initialization
	void Start () {
		guiObject.SetActive(false);
	}

	void OnTrigger(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			guiObject.SetActive(true);
			if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
			{
				Application.LoadLevel(levelToLoad);

			}
			
		}
	}

	void OnTrigerExit()
	{
		guiObject.SetActive(false);
	}
}