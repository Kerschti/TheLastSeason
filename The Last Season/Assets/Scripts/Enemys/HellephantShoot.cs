using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantShoot : MonoBehaviour {


	Transform player;
	public Transform trunk;
	public GameObject bullet;

	void Awake(){
		player = GameObject.FindWithTag ("Player").transform;
	}

	void Update(){
		transform.LookAt (player);
	}

	void OnTriggerEnter(Collider other){
        
		if (other.gameObject.tag == "Player") {
			StartCoroutine ("Shooting");
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			StopCoroutine ("Shooting");
		}
	}

	IEnumerator Shooting(){
        Debug.Log("Hallo");
		while (true) {
            
			Instantiate (bullet, trunk.position, trunk.rotation);
			yield return new WaitForSeconds (1);

		}


	}
		

	}






