using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerableCloud : MonoBehaviour {

    private Transform Cloud;

	// Use this for initialization
	void Start () {

        Cloud = this.transform.parent;
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cloud.transform.SetParent(other.transform);


        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cloud.transform.SetParent(null);
        }
    }


}
