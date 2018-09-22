using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorOpenHouse : MonoBehaviour {	
	
	public string levelToLoad;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			SceneManager.LoadScene ("Room", LoadSceneMode.Single);

		}
	}
}
