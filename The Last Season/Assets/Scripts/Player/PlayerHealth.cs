using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health = 100;
    public int curHealth;
    public Transform spawnPoint;
    private bool damaged;
    private bool dead = false;
    private Animator anim;
    private PlayerMovement playerMove;
    private float lastY;                        // Float that stores last Position of player when falling
    private float lastYTravelDistance;          // Float that stores the calculated distance traveled beween last frame of falling and now
    private float fallHeight = 0;               // Float to determine if falling.
    protected float deathHeight = 8;            // Float of max Height you can fall before dieing.
    private bool wasFalling = false;            // Determine if player fell in last frame.

    // Use this for initialization
    
    
    //@Meltem
    public Slider HealthBar;
    
    void Start()
    {
        curHealth = health;
        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
        
        // @Mel
        //HealthBar = GetComponent<Slider>();

    }


    void FixedUpdate()
    {
        CheckForFall();
    }



    public void TakeDamage(int amount)
    {

        damaged = true;

        curHealth -= amount;
        HealthBar.value = curHealth;


        Debug.Log("Health of Player: " + curHealth);

        if (curHealth <= 0 && !dead)
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

    void CheckForFall()
    {

        if (!playerMove.IsGrounded())
        {

            // Calculate the distance between players current height and the height he was in the last frame.
            lastYTravelDistance = transform.position.y - lastY;

            // If difference is negative, store descending value. 
            fallHeight += lastYTravelDistance < 0 ? lastYTravelDistance : 0;

            // Cache players current Y position for comparison in the next frame.
            lastY = transform.position.y;

            //store that a fall happened
            //wasFalling = true;

            //Debug.Log("Travel Distance: "+ lastYTravelDistance);
        }
        else if (playerMove.IsGrounded()/* && wasFalling*/)
        {

            // Check to see if player passed the allowed falling distance and kill the player if necessary.
            if (fallHeight <= -deathHeight)
                TakeDamage(100);

            //reset fall height since we landed (doesn't matter if we're dead or alive)
            fallHeight = 0;

            //rest lastY
            //lastY = transform.position.y;
            //checked if player fell to death now prevent repeating
            //wasFalling = false;
        }

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