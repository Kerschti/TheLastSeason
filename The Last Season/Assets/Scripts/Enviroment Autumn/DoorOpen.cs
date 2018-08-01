using System.Collections;
using UnityEngine;

public class DoorOpen : MonoBehaviour {	
	
	public string levelToLoad;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			Application.LoadLevel(levelToLoad);
		
		}
	}
}