using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : MonoBehaviour
{
    //private Vector3 movement;                   // The vector to store the direction of the player's movement.
    private Animator anim;                      // Reference to the animator component.
    private Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    private int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    private int waterMask;                      // A layer mask for the Water layer.
    private Vector2 rotation;                   // Vector to store the direction in wich the player should turn.
    private CapsuleCollider col;                // Reference to the Players CapsuleCollider.
    private float lastY;                        // Float that stores last Position of player when falling
    private float lastYTravelDistance;          // Float that stores the calculated distance traveled beween last frame of falling and now
    private float fallHeight = 0;               // Float to determine if falling.
    private float deathHeight = 8;              // Float of max Height you can fall before dieing.
    private bool wasFalling = false;            // Determine if player fell in last frame.
    private float h;                            // Stores horizontal input
    private float v;                            // Stores vertical input.
    private float initTime;                     // Stores inital value for timeUntilRuns.
    private float initSpeed;                    // Stores initial value for Speed;
    private float SpeedVelocity;                // Obligatory Velocity value (0) for speedcalculation.
    private float curSpeed;                     // Stores current Speed of player.

    public float smoothTime = 0.1f;             // Smoothtime for smoothing playermovement.
    public float timeUntilRuns = 20;            // Timer until the player runs.
    public float jumpForce = 2f;                // Upward force for jumping.
    public float Speed = 7f;                    // moving speed.
    public float runSpeed = 5f;                 // run speed.
    public float rotationSpeed = 75f;           // rotation speed.

    Transform cameraTrans;                      // camera transform.
    Vector2 dir;                                // Vector2 for calculating movement & rotation of player.


    void Awake()
    {
        // Create a layer mask for the floor layer.

        floorMask = LayerMask.GetMask("Floor");
        waterMask = LayerMask.GetMask("Water");
        col = GetComponent<CapsuleCollider>();
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cameraTrans = Camera.main.transform;
        initTime = timeUntilRuns;
        initSpeed = Speed;

    }

    void GetInput(){
        // Store the input axes.
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void Update()
    {
        // Get InputAxis.
        GetInput();

        // Turn the player.
        Turning();
    }



    void FixedUpdate()
    {

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            //if jumpKey was pressed, jump upwards with relative force.
            playerRigidbody.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


        // Check if player is falling to death.
        CheckForFall();


        // Move the player around the scene.
        //TODO: prevent moving the player while he's attacking 
        Move();

        // Animate the player.
        Animating();

        // Calculate Time.
        TimeUntilRun();

    }

    void TimeUntilRun()
    {
        // Check if the Player is walking and isn't swimming
        bool IsWalking = h != 0f || v != 0f && !IsInWater();

        if(IsWalking && timeUntilRuns >= 0)
        {
            // Subtract actual Time from timer, if Timer <= 0, trigger running state & stop checking, unless player stopped moving. 
            timeUntilRuns -= Time.deltaTime;

        }
        else if(!IsWalking)
        {
            timeUntilRuns = initTime;
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                                                                   col.bounds.min.y,
                                                                   col.bounds.center.z),
                                    col.radius * 1.2f, floorMask);
    }

    private bool IsInWater()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                                                                  col.bounds.min.y,
                                                                  col.bounds.center.z),
                                    col.radius * 1.2f, waterMask);
    }

    void Move()
    {

        // Set speed based on direction & run or walkspeed, based on how long he moved.
        Speed = (timeUntilRuns <= 0 ? runSpeed : initSpeed) * dir.magnitude;

        // Smoothen speedgain over time.
        curSpeed = Mathf.SmoothDamp(curSpeed, Speed, ref SpeedVelocity, smoothTime);

        // Translate Player forward by speed. 
        transform.Translate(transform.forward * curSpeed * Time.deltaTime, Space.World);
        //playerRigidbody.AddForce(transform.forward * movement * Time.deltaTime, ForceMode.Impulse);
        //Debug.Log(movement);
        //playerRigidbody.velocity = transform.forward * movement * Time.deltaTime;


    }



    void Turning()
    {
        rotation.Set(h, v);
        dir = rotation.normalized;

        if(dir != Vector2.zero)
        {
            // Calculate players rotation by radians. Add CamRotation, so player is going forward according to camera rotation.
            float targetRot = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + cameraTrans.eulerAngles.y;
            // Set transforms rotation smoothly.
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRot, ref rotationSpeed, 0.15f);
        }

    }


    void CheckForFall()
    {
        
        if (!IsGrounded())
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
        else if(IsGrounded()/* && wasFalling*/)
        {
            
            // Check to see if player passed the allowed falling distance and kill the player if necessary.
            if (fallHeight <= -deathHeight)
                GetComponent<PlayerHealth>().TakeDamage(100);
            
            //reset fall height since we landed (doesn't matter if we're dead or alive)
            fallHeight = 0;

            //rest lastY
            //lastY = transform.position.y;
            //checked if player fell to death now prevent repeating
            //wasFalling = false;
        }


    }

    void Animating()
    {
        bool IsWalking = h != 0f || v != 0f && !IsInWater();
        float running = timeUntilRuns <= 0 ? 1f : 0.5f;

        //bool isInWater = !IsWalking && !IsGrounded();
        //anim.SetBool("IsWalking", IsWalking);
        anim.SetBool("IsInWater", IsInWater());


        if (!IsGrounded())
        {
            anim.SetBool("IsJumping", true);
        }
        else if (IsGrounded())
        {
            anim.SetBool("IsJumping", false);
        }



        if (IsWalking)
        {
            
            anim.SetFloat("SpeedPerc", running);

        }
      
        else if (!IsWalking)
        {
            anim.SetFloat("SpeedPerc", 0);
        }



    }
}
