using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantShoot : MonoBehaviour {


	Transform player;
	public Transform trunk;
	public GameObject bullet;
    private float timer;
    public float maxTime;

	void Awake(){
		player = GameObject.FindWithTag ("Player").transform;
	}

	void Update(){
		transform.LookAt (player);
        timer += Time.deltaTime;
        if(timer >= maxTime){
            timer = 0;
            Instantiate(bullet, trunk.position, trunk.rotation);
        }


	}

	void OnTriggerEnter(Collider other){
        
		if (other.gameObject.tag == "Player") {
			//StartCoroutine ("Shooting");
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			//StopCoroutine ("Shooting");
		}
	}

	//IEnumerator Shooting(){
  //      Debug.Log("Hallo");
		//while (true) {
            
			
  //          yield return new WaitForSeconds (maxTime);

		//}


	}
		

	






