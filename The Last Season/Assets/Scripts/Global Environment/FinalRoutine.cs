using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoutine : MonoBehaviour {

    private Flash flash;
    private ParticleSystem rain;
    private ParticleSystem dust;

    // Class that sores all the Objects invovled.
    [System.Serializable]
    public class EndObjects
    {
        public GameObject _rain;
        public GameObject _dust;
        public Material skybox;
        public Light directionallight;
        public Gradient gradient;
        public GameObject finalScreen;
    }


    public float duration = 20;

    float t;

    public EndObjects end = new EndObjects();

	// Use this for initialization
	void Start () {
        //Initialize the needed Gomponents.
        flash = Object.FindObjectOfType<Flash>();
        rain = end._rain.GetComponent<ParticleSystem>();
        dust = end._dust.GetComponent<ParticleSystem>();
	}


    // Will be called when Endboss is dead.
    public void TheEnd()
    {

        flash.notTheEnd = false;
        FindObjectOfType<AudioManager>().Pause("Theme");
        dust.Stop();
        rain.Stop();
        //Set the new Skybox
        RenderSettings.skybox = end.skybox;

        //slowly make the lightning lighter.
        while (t < duration)
        {
            float value = Mathf.Lerp(0f, 1f, t);
            t += Time.deltaTime / duration;
            end.directionallight.color = end.gradient.Evaluate(value);
        }
        //then stop the game after some thime.
        StartCoroutine(StopGame());

    }

    IEnumerator StopGame()
    {
        yield return new WaitForSeconds(5);
        end.finalScreen.SetActive(true);
        yield return new WaitForSeconds(10);
        Debug.Log("Application Quit now");
        Application.Quit();
    }
}
