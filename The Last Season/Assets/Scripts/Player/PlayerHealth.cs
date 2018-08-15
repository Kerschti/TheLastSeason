﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 100;
    public int curHealth;
    public Transform spawnPoint;
    private bool damaged;
    private bool dead = false;
    private Animator anim;
    private PlayerMovement playerMove;

    // Use this for initialization
    void Start()
    {
        curHealth = health;
        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {

        damaged = true;

        curHealth -= amount;

        Debug.Log("Health of Player: " + curHealth);

        if(curHealth <=0 && !dead)
        {
            Death();
        }


    }

    void Death()
    {
        dead = true;
        playerMove.enabled = false;
        anim.SetTrigger("IsDead");
        StartCoroutine(SpawnAfterSec());

    }

    private IEnumerator SpawnAfterSec()
    {
        yield return new WaitForSeconds(5f);
        transform.position = spawnPoint.position;

        curHealth = health;
        playerMove.enabled = true;
        dead = false;

        anim.SetTrigger("Respawned");
    }
}
