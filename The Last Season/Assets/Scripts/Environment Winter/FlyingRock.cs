using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRock : MonoBehaviour {


    //public GameObject rock;
    public GameObject player;

    private Collider playerCollider;


	// Use this for initialization
	void Start () {
        playerCollider = player.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if(other == playerCollider){
            this.transform.Translate(Vector3.up);
        }
    }


}
