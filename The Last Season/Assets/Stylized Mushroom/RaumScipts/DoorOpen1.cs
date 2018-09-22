using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorOpen1 : MonoBehaviour {	
	
	public string levelToLoad;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			SceneManager.LoadScene ("Room2", LoadSceneMode.Single);

		}
	}
}