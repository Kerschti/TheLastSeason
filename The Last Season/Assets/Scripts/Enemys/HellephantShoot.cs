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
<<<<<<< HEAD
    }
=======
        timer += Time.deltaTime;
        if(timer >= maxTime){
            timer = 0;
            Instantiate(bullet, trunk.position, trunk.rotation);
        }


	}
>>>>>>> master

    //if player in trigger start shooting
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
<<<<<<< HEAD
			StartCoroutine ("Shooting");
            
        }

  
=======
			//StartCoroutine ("Shooting");
		}
>>>>>>> master
	}

    //If player not in trigger stop shooting
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
<<<<<<< HEAD
            
            StopCoroutine ("Shooting");
		}
	}

    //Create new bullet every one second
    IEnumerator Shooting(){
        Debug.Log("Elefant schießt");

		while (true) {
			Instantiate (bullet, trunk.position, trunk.rotation);
            yield return new WaitForSeconds(1);
           

        }
=======
			//StopCoroutine ("Shooting");
		}
	}

	//IEnumerator Shooting(){
  //      Debug.Log("Hallo");
		//while (true) {
            
			
  //          yield return new WaitForSeconds (maxTime);

		//}
>>>>>>> master


    }

<<<<<<< HEAD

}
=======
	
>>>>>>> master






