using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public float enemyTriggerDist;              // the distance at which the enemies start following the player.

    private Transform player;                   // Refence to player.
    private NavMeshAgent nav;                   // Reference to the NavMeshAgent.
    private EnemyHealth health;                 // Health script of Enemies.
    private PlayerHealth pHealth;               // Health script of player.
    private bool isRhino = false;               // bool to check if the GameObject carrying this script is rhinoish.
    private Animator anim;                      // Reference to the animator.
    private RhinoFire rhinoFire;                // Reference to rhinoFire Script

	// Use this for initialization
	void Start () {

        //Setting things up.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        pHealth = player.GetComponent<PlayerHealth>();
        if (this.name == "Rhino_PBR") 
        {
            // if this is a huge Rhino, initialize some more.
            isRhino = true;
            anim = GetComponent<Animator>();
            rhinoFire = GetComponent<RhinoFire>();
        }

    }
	
	// Update is called once per frame
	void Update () {

        if(pHealth.curHealth >= 0 && !health.isDead && TriggerEnemyMovement())
        {
            //we need to check if the enemy is a big sparkling rhino, because the usual procedure is n/a for it.
            if (isRhino)
            {
                nav.enabled = true;
                nav.SetDestination(player.position);
                //Make the Rhino walk if he follows the player.
                anim.SetBool("IsWalking", true);
                if (rhinoFire.IstriggerEnter())
                {
                    // if the rhino is about to fire some fireballs, stop following player and playing the animation.
                    nav.enabled = false;
                    anim.SetBool("IsWalking", false);
                }
            }
            else
            {
                // for everthing else standardprocedure is applicable.
                nav.enabled = true;
                nav.SetDestination(player.position);
            }
          

        }
        else
        {
            // when enemy is dead or player is out of reach, disable enemy movement.
            nav.enabled = false;
            //if your are a rhino you shold stop walking too.
            if (isRhino) anim.SetBool("IsWalking", false);

        }
	}

    public bool TriggerEnemyMovement() 
    {
        // calculate current offstet to player.
        Vector3 offset = player.position - transform.position;
        //calculate distance by sqrMag, DistanceTo has poorer efficiancy.
        float distanceToPlayer = offset.sqrMagnitude; 

        //return true if player is in desired distance.
        return distanceToPlayer < enemyTriggerDist * enemyTriggerDist;
    }

}
