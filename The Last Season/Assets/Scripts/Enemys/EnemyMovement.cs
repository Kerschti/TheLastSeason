using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    private Transform player;
    private NavMeshAgent nav;
    private EnemyHealth health;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {

        if(!health.isDead)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
	}

    
}
