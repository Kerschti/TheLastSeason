﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : MonoBehaviour
{

<<<<<<< HEAD
    // Use this for initialization
    public float BulletSpeed;
=======
	// Use this for initialization
	public float BulletSpeed;
>>>>>>> master
    protected float Animation;

    public int attackDamage = 10;
    GameObject player;
    PlayerHealth playerhealth;
    EnemyHealth enemyhealth;
    bool playerInRange;
 

    Vector3 beginP;
    Vector3 targetP;

    void Awake()
    {

        beginP = GameObject.FindWithTag("TrunkEnd").transform.position;
        targetP = GameObject.FindWithTag("Player").transform.position;
        Destroy(this.gameObject, 8.0f);

        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();
        enemyhealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;

            Attack();
        }
    }

    void Update()
    {
        Debug.Log("Jetzt sollte die Parabel kommen");
        Animation += Time.deltaTime;
<<<<<<< HEAD
=======
        Animation = Animation % 5;
>>>>>>> master
        transform.position = Parabola.Parabola1(beginP, targetP, 5f, Animation / 5f);
        Debug.Log("Parabel ist fertig aufgebaut");
    }

    void Attack()
    {

        if(playerhealth.curHealth > 0)
        {
            playerhealth.TakeDamage(attackDamage);
            Debug.Log(playerhealth);
        }
       
    }

}