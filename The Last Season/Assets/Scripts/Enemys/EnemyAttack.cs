using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;

    private float timer;
    private GameObject player;
    private bool playerInRange;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;

    private Animator anim;

    public int atkDamage = 10;

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

        if (timer >= timeBetweenAttacks && playerInRange)
        {
           
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;

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
        }
    }

}
