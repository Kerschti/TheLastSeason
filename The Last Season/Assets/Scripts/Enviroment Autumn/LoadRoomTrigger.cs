using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoomTriger : MonoBehaviour {
	void Start () {
		// Only specifying the sceneName or sceneBuildIndex will load the scene with the Single mode
		SceneManager.LoadScene ("Room", LoadSceneMode.Additive);
	}
}