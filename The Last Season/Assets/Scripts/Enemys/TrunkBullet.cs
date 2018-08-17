using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : MonoBehaviour {

	// Use this for initialization
	
	public float BulletSpeed;
    protected float Animation;


    public int attackDamage = 10;
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
     

    //Startposition trunkEnd
    Vector3 beginP;
    //Endposition player
    Vector3 targetP;

	void Awake() {
		
        beginP = GameObject.FindWithTag("TrunkEnd").transform.position;
        targetP = GameObject.FindWithTag("Player").transform.position;
        //Destroy bullet after 8 sec.
        Destroy(this.gameObject, 8.0f);

        player = GameObject.FindGameObjectWithTag("Player");//targetP
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();

	}

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
            Attack();
        }
       
    }




    void Update()
    {
        Animation += Time.deltaTime;        //TIME TO BUILD UP PARABOLA
        transform.position = Parabola.Parabola1(beginP, targetP, 5f, Animation / 5f);
       
        //if (playerInRange)
        //{
        //    // ... attack.
        //    Attack();
        //}
    }




    void Attack()
    {
        // If the player has health to lose...
        if (playerHealth.curHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }
 
}
