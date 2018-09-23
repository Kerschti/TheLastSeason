using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public float enemyTriggerDist;

    private Transform player;
    private NavMeshAgent nav;
    private EnemyHealth health;
    private bool isRhino = false;
    private Animator anim;
    private RhinoFire rhinoFire;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        if (this.name == "Rhino_PBR") 
        {
            isRhino = true;
            anim = GetComponent<Animator>();
            rhinoFire = GetComponent<RhinoFire>();
        }

    }
	
	// Update is called once per frame
	void Update () {

        if(!health.isDead && TriggerEnemyMovement())
        {
            //we need to check if the enemy is a big sparkling rhino, because the usual procedure is n/a for it.
            if (isRhino)
            {
                nav.enabled = true;
                nav.SetDestination(player.position);
                //
                anim.SetBool("IsWalking", true);
                if (rhinoFire.IstriggerEnter())
                {
                    nav.enabled = false;
                    anim.SetBool("IsWalking", false);
                }
            }
            else
            {
             
                nav.enabled = true;
                nav.SetDestination(player.position);
            }
          

        }
        else
        {
            Debug.Log("NOT ACITVVVVVVVVVE" + health.isDead + " #####" + TriggerEnemyMovement());
            nav.enabled = false;
            if (isRhino) anim.SetBool("IsWalking", false);

        }
	}

    public bool TriggerEnemyMovement() 
    {
        Vector3 offset = player.position - transform.position;
        float distanceToPlayer = offset.sqrMagnitude; 
        //Debug.Log("DISTANCE" + this.name + "#########" + distanceToPlayer);
        return health.currentHealth > 0 &&
               distanceToPlayer < enemyTriggerDist * enemyTriggerDist;
    }

}
