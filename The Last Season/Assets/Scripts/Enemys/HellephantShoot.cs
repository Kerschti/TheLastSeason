using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantShoot : MonoBehaviour {


    public Transform trunk;
    public GameObject bullet;
    private Transform player;

    float timer;
    public float timeBetweenAttacks = 1f;

    public bool InRange = false;

    private Transform trunkend;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;

        trunkend = GameObject.FindWithTag("TrunkEnd").transform;

    }

    //if player in trigger start shooting
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InRange = true;
        }
    }

    void Update()
    {
        transform.LookAt(player);

        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && InRange )
        {
            // ... attack.
            Shooting();
        }

    }
   

    //If player not in trigger stop shooting
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InRange = false;
            Debug.Log("Der Elefant schießt nicht mehr");
        }
    }

    void Shooting()
    {
        // Reset the timer.
        timer = 0f;
        Instantiate(bullet, trunkend.position, trunkend.rotation);

    }


}



