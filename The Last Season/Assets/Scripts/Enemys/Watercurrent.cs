﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Watercurrent : MonoBehaviour {

    public GameObject waypoints;
    private GameObject player;
    public int num = 0;

    public float minDist;
    public float speed;

    public bool go = false;



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            go = true;
            Debug.Log("Trigger GO IST JETZT:" + go);


        }

    }


    // Update is called once per frame
    void Update() {

        if (waypoints)
        {
            float dist = Vector3.Distance(player.transform.position, waypoints.transform.position);

            if (go)
            {
                if (dist > minDist)
                {
                    //.Log(dist);
                    Move();
                    Debug.Log("MOVE IS CALLING");
                }
                else
                {
                    Debug.Log("Player ist am Ende");
                    waypoints = null;
                    go = false;
                    Debug.Log("ELSE GO IST JETZT:" + go);

                    //Debug.Log("BEFORE DESTROYING:"+ waypoints.transform.position);

                    //Destroy(waypoints);

                    //Debug.Log("AFTER DESTROYING:" + waypoints.transform.position);

                    //Undo.DestroyObjectImmediate(waypoints);

                    //Debug.Log("AFTER UNDO:" + waypoints.transform.position);

                }

            }
        }

        
    }

    public void Move()
    {
        player.transform.LookAt(waypoints.transform.position);
        player.transform.position += player.transform.forward * speed * Time.deltaTime;

        Debug.Log("IN MOVE");
        
    }
}
	



