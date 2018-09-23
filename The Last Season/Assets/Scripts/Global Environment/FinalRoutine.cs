using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoutine : MonoBehaviour {

    private Flash flash;
    private ParticleSystem rain;
    private ParticleSystem dust;

    public GameObject _rain;
    public GameObject _dust;
    public Material skybox;
    public float duration = 20;
    public Light directionallight;
    public Gradient gradient;
    public GameObject finalScreen;

    float t;


	// Use this for initialization
	void Start () {
        flash = Object.FindObjectOfType<Flash>();
        rain = _rain.GetComponent<ParticleSystem>();
        dust = _dust.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TheEnd()
    {
        flash.notTheEnd = false;
        FindObjectOfType<AudioManager>().Pause("Theme");
        dust.Stop();
        rain.Stop();
        RenderSettings.skybox = skybox;

        while (t < duration)
        {
            float value = Mathf.Lerp(0f, 1f, t);
            t += Time.deltaTime / duration;
            directionallight.color = gradient.Evaluate(value);
        }
        StartCoroutine(StopGame());

    }

    IEnumerator StopGame()
    {
        yield return new WaitForSeconds(5);
        finalScreen.SetActive(true);
        yield return new WaitForSeconds(10);
        Debug.Log("Application Quit now");
        Application.Quit();
    }
}
