using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoFire : MonoBehaviour {

    public GameObject flames;                       //Gameobject for prefab bullet                   
    private Transform player;                       //Position information from player needed

    private float timer;
    private float timeBetweenAttacks = 1f;          //Time between shooting new bullet
    private bool InRange;                           //Is Player entering trigger?

    public Transform tongue;                        //saves tongue position
    public GameObject rino;                         //saves Gameobj rino

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").transform;
        rino = transform.Find("Rino").gameObject;
        InRange = false;
        flames = GameObject.FindWithTag("Flames");
    }

    //if player in trigger start shooting
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //set player in range true
            InRange = true;

            //finding position of childelement trunkend from trunk1
            tongue = rino.transform.Find("tongue");

            //give trunkend position to Trunkbullet
            //TrunkBullet.SetBeginP(trunkendPos);
        }
    }

    void Update()
    {
        //Hellephant looks at player
        transform.LookAt(player);

        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && InRange)
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
        Instantiate(flames);
    }
}






