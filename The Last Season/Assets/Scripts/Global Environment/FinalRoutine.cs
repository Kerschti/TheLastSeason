using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoutine : MonoBehaviour {

    private Flash flash;
    private ParticleSystem rain;
    private ParticleSystem dust;

    public GameObject _rain;
    public GameObject _dust;



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
        dust.Stop();
        rain.Stop();
    }
}
