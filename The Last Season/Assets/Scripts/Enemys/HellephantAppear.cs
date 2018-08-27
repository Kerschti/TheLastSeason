using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantAppear : MonoBehaviour {


    GameObject killerhellephant;


	void Awake () {
        killerhellephant = GameObject.FindGameObjectWithTag("Killerhellephant");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            

        }
    }
}
