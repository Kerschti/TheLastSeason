using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;                    // Initial Health of player.
    public Transform spawnPoint;                // Transform of the ReSpawn Point(if player dies he respawns there.)

    private bool dead = false;                  //bool that stores if player is dead.
    private Animator anim;                      // Reference to players Animator.
    private PlayerMovement playerMove;          // PlayerMovement script reference
    private float lastY;                        // Float that stores last Position of player when falling
    private float lastYTravelDistance;          // Float that stores the calculated distance traveled beween last frame of falling and now
    private float fallHeight = 0;               // Float to determine if falling.
    protected float deathHeight = 8;            // Float of max Height you can fall before dieing.
    private bool wasFalling = false;            // Determine if player fell in last frame.
    [HideInInspector]
    public int curHealth;                       // Players Current Health.
    [HideInInspector]
    public bool isOnParaCloud = false;          // Check if player is on a cloud that is about to fly a parabola


    public Slider HealthBar;     //@Meltem
    
    void Start()
    {
        // setting up Health for player and getting Components.
        curHealth = health;
        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
    }


    void FixedUpdate()
    {
        // If player is and was not on a certain cloud (its an island now btw)...
        if (!isOnParaCloud)
        {
            // Check if the player is falling & if he fell to his death.
            CheckForFall();
        }
    }



    public void TakeDamage(int amount)
    {

        curHealth -= amount;     //@Meltem

        HealthBar.value = curHealth;     //@Meltem

        // if player has no more health and is not dead already, die.
        if (curHealth <= 0 && !dead)
        {
            Death();
        }
        

    }

    void Death()
    {
        // Play dead sound, set dead bool to true and play animation.
        FindObjectOfType<AudioManager>().Play("Dead");
        dead = true;
        playerMove.enabled = false;
        anim.SetTrigger("IsDead");
        //Start the Coroutine that brings him back to live.
        StartCoroutine(SpawnAfterSec());

    }

    void CheckForFall()
    {

        if (!playerMove.IsGrounded() && !playerMove.IsInWater())
        {

            // Calculate the distance between players current height and the height he was in the last frame.
            lastYTravelDistance = transform.position.y - lastY;

            // If difference is negative, store descending value. 
            fallHeight += lastYTravelDistance < 0 ? lastYTravelDistance : 0;

            // Cache players current Y position for comparison in the next frame.
            lastY = transform.position.y;

        }
        else if (playerMove.IsGrounded() && !playerMove.IsInWater())
        {

            // Check to see if player passed the allowed falling distance and kill the player if necessary.

            if (Mathf.Abs(fallHeight) >= deathHeight)
            {
                TakeDamage(100);
            }

            //reset fall height since we landed (doesn't matter if we're dead or alive)
            fallHeight = 0;

        }

    }

    private IEnumerator SpawnAfterSec()
    {
        // when player died, wait for some seconds
        yield return new WaitForSeconds(5f);
        // then reset everything and bring him to the last spawnpoint position.
        dead = false;
        transform.position = spawnPoint.position;
        curHealth = health;
        playerMove.enabled = true;

        anim.SetTrigger("Respawned");
    }

    // Function for setting the actual spawnPoint.
    public void SetSpawnPoint(Transform _spawnPoint)
    {
        spawnPoint = _spawnPoint;
    }

}