using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorOpen : MonoBehaviour {	
	
	public string levelToLoad;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			SceneManager.LoadScene ("Room1", LoadSceneMode.Single);

		}
	}
}
