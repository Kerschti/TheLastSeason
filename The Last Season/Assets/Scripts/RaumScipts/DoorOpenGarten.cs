using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorOpenGarten : MonoBehaviour {	
	
	public string levelToLoad;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			SceneManager.LoadScene ("MeltemsScene", LoadSceneMode.Single);

		}
	}
}