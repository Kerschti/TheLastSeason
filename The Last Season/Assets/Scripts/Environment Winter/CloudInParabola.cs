﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudInParabola : MonoBehaviour {

    public Transform end;
    public GameObject player;
    public Transform father;
    public GameObject parcours;
    public GameObject firstIsland;


    private Vector3 startPos;
    private Vector3 endPos;
    private bool startAnim = false;
    private float animTimer;
    private PlayerHealth playerHealth;

    private void Start()
    {
        startPos = father.position;
        endPos = new Vector3(transform.position.x + 10, 0, transform.position.z);
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            startAnim = true;
            playerHealth.isOnParaCloud = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //playerHealth.isOnParaCloud = false;
            Destroy(firstIsland, 4f);
            Destroy(parcours, 6f);

        }
    }


    private void Update()
    {
        if(startAnim)
        {
            animTimer += Time.deltaTime;
            father.position = Parabola.Parabola1(startPos, endPos, 5f, animTimer / 7f);

            if(transform.position.y <= 0)
            {
                startAnim = false;
            }

        }
    }
}
