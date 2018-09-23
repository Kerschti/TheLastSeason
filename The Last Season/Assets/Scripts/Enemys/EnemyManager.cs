﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{

    public GameObject[] enemies;    //Enemy prefab to be spawned.
    public float spawnTime = 4f;    //Time until new Enemy spawns.
    public int spawnDistance = 30;
    public int upperSpawnLimit = 2;

    Vector3 dirVec = Vector3.zero;

    private GameObject player;          //Reference to player 
    private PlayerHealth playerHealth;  //Reference to players health script
    private int spawnCount = 0;
    private bool isInvoking = true;
    private GameObject spawnInstance;
    private Collider spawnArea;
    private Vector3 _spawnAreaPos;

	// Use this for initialization
	void Start () {

        spawnArea = GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);

	}

    Vector3 GetSpawnPos()
    {
        return player.transform.position + dirVec * spawnDistance;
    }

    bool ValidateSpawnPos(Vector3 spawnPos)
    {
        if (spawnArea.bounds.Contains(spawnPos))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    void Spawn(){

        if(playerHealth.curHealth <= 0f) return;

        if (spawnCount > upperSpawnLimit && spawnInstance)
        {
            return;
        } else if(spawnCount > upperSpawnLimit && !spawnInstance)
        {
            spawnCount = 0;
        }

        spawnCount++;
       
        Vector3 spawnPos = GetSpawnPos();
        if (ValidateSpawnPos(spawnPos))
        {


            spawnPos.y = 50f;

            int enemyIndex = Random.Range(0, enemies.Length);

            RaycastHit hit;
            if (Physics.Raycast(spawnPos, Vector3.down, out hit, 60f, LayerMask.GetMask("Floor")))
            {

                spawnPos.y = hit.point.y;
            }
            spawnInstance = Instantiate(enemies[enemyIndex], spawnPos, Quaternion.identity);
            //spawnInstance.GetComponent<NavMeshAgent>().Warp(spawnPos);
        }
    }

    // Update is called once per frame
    void Update () {
        dirVec = player.transform.forward;


        //Debug.Log(dirVec);
        if(dirVec != Vector3.zero)
        {
            if (!isInvoking)
            {
                InvokeRepeating("Spawn", spawnTime, spawnTime);
                isInvoking = true;
            }
        }
        else
        {
            CancelInvoke("Spawn");
            isInvoking = false;
        }
      
	}
}
