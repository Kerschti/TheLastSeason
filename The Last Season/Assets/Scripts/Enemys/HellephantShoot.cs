using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantShoot : MonoBehaviour {


	public float triggerDistanceToPlayer = 10f;
	public int defaultAttackDamage = 5;
	public float defaultAttackFrequency = 2f;
	[HideInInspector]
	public bool didTriggerAttack = false;

	private GameObject player;
	private Animator anim;
	private EnemyHealth enemyHealth;
	private EnemyAttack enemyAttack;
	private SphereCollider sphereCollider;
	private string attack = "Attack";
	//private string idledance = "DanceIdle";

	int attackIndex;


	// Use this for initialization
	void Start () {
		
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator>();
		enemyHealth = GetComponent<EnemyHealth>();
		enemyAttack = GetComponent<EnemyAttack>();
		attackIndex = Random.Range(1, 4);
		sphereCollider = GetComponent<SphereCollider>();
		int randIndex = Random.Range(1, 3);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 enemyToPlayer = player.transform.position - transform.position;

		if (enemyToPlayer.sqrMagnitude < triggerDistanceToPlayer * triggerDistanceToPlayer && !didTriggerAttack && !enemyHealth.isDead) //using sqrMagnitude for performance reasons 
			//Debug.Log("TRIGGER GUNNAR CLOSE COMBAT #################");

			didTriggerAttack = true;

			sphereCollider.radius = 0.55f; //increase collider radius for special attacks 

			attack = "Attack" + attackIndex;
			anim.SetTrigger(attack);

		}

	}






