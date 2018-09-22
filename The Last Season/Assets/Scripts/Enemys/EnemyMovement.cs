using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public float enemyTriggerDist;

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

        if(!health.isDead && TriggerEnemyMovement())
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
	}

    public bool TriggerEnemyMovement() 
    {
        Vector3 offset = player.position - transform.position;
        float distanceToPlayer = offset.sqrMagnitude; 
//        Debug.Log("DISTANCE" + distanceToPlayer);
        return health.currentHealth > 0 &&
               distanceToPlayer < enemyTriggerDist * enemyTriggerDist;
    }

}
