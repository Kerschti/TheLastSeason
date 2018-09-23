using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // leave some time between attacks.

    private float timer;                        // the timer.
    private GameObject player;                  // Reference to player.
    private bool playerInRange;                 // a bool to determine if player is in Range of enemy.
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;

    private Animator anim;

    public int atkDamage = 10;                  // the dmg an enemy does.

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // if the player is in Range and the time is right
        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }
        //if the player is dead..
        if (playerHealth.curHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        //reset timer.
        timer = 0f;

        // deal damage to player if enemie & player arent dead.
        if (playerHealth.curHealth > 0 && enemyHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(atkDamage);
            anim.SetBool("IsAttacking", true);
           
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
            anim.SetBool("IsAttacking", false);
        }
    }

}
