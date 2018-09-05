/*using System.Collections;
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
*/

/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour {
	void Start () {
		// Only specifying the sceneName or sceneBuildIndex will load the scene with the Single mode
		SceneManager.LoadScene ("Room", LoadSceneMode.Additive);
	}
}

*/