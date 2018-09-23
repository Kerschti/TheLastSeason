using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantShoot : MonoBehaviour {


    public GameObject bullet;                       //Gameobject for prefab bullet                   
    private Transform player;                       //Position information from player needed

    private float timer;
    private float timeBetweenAttacks = 0.3f;        //Time between shooting new bullet
    private bool InRange;                           //Is Player entering trigger?

    public Transform trunkendPos;                   //saves trunkend position
    public GameObject trunk1;                       //saves Gameobj trunk

    //Initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        trunk1 = transform.Find("Trunk1").gameObject;
        InRange = false;
    }

    //if player in trigger start shooting
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //set player in range true
            InRange = true;

            //finding position of childelement trunkend from trunk1
            trunkendPos = trunk1.transform.Find("TrunkEnd");

            //give trunkend position to Trunkbullet
            TrunkBullet.SetBeginP(trunkendPos);
        }
    }

    void Update()
    {
        //Hellephant looks at player
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
            //player isn't in range anymore
            InRange = false;
        }
    }

    void Shooting()
    {
        // Reset the timer.
        timer = 0f;

        //New bullet
        Instantiate(bullet);
    }


}



