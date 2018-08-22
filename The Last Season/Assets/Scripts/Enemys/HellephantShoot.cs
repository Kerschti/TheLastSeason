using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantShoot : MonoBehaviour {


	Transform player;
	public Transform trunk;
	public GameObject bullet;

    private bool playerInRange;
    private PlayerHealth playerHealth;
    public int atkDamage = 5;
    private float timer;
    public float timeBetweenAttacks = 0.5f;

    void Awake(){
		player = GameObject.FindWithTag ("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        
    }

    void Update(){
		transform.LookAt (player);

        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }
    }

    //if player in trigger start shooting
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			StartCoroutine ("Shooting");
            playerInRange = true;
        }

  
	}

    //If player not in trigger stop shooting
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
            playerInRange = false;
            StopCoroutine ("Shooting");
		}
	}

    void Attack()
    {
        if (playerHealth.curHealth > 0)
        {
            playerHealth.TakeDamage(atkDamage);
        }
    }

    //Create new bullet every one second
    IEnumerator Shooting(){
        
		while (true) {
			Instantiate (bullet, trunk.position, trunk.rotation);
            yield return new WaitForSeconds(1);
		}


	}


}






