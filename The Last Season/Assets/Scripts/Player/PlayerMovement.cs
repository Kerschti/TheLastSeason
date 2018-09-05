using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 movement;                   // The vector to store the direction of the player's movement.
    private Animator anim;                      // Reference to the animator component.
    private Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    private int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    private int waterMask;
    //?private float camRayLength = 100f;          // The length of the ray from the camera into the scene.    
    private Vector2 rotation;                   // Vector to store the direction in wich the player should turn.
    private CapsuleCollider col;                // Reference to the Players CapsuleCollider.
    private float lastY;                        // Float that stores last Position of player when falling
    private float lastYTravelDistance;          // Float that stores the calculated distance traveled beween last frame of falling and now
    private float fallHeight = 0;               // Float to determine if falling.
    private float deathHeight = 6;              // Float of max Height you can fall before dieing.
    private bool wasFalling = false;            // Determine if player fell in last frame.
    private bool isSwimming = false;
    private float h;                            // Stores horizontal input
    private float v;                            // Stores vertical input.
    private float initTime;
    private float initSpeed;

    public float timeUntilRuns = 20;
    public float jumpForce = 2f;                // Upward force for jumping.
    public float Speed = 7f;                    // moving speed.
    public float runSpeed = 5f;
    public float rotationSpeed = 75f;           // rotation speed.
    Transform cameraTrans;

    Vector2 dir;


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

        //transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        // Turn the player.
        Turning();
    }



    void FixedUpdate()
    {
       
        //anim.SetFloat("speedX", Mathf.Abs(h));
        //anim.SetFloat("speedY", Mathf.Abs(v));
       

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


        //check if player is falling to death
        CheckForFall();


        // Move the player around the scene.
        //TODO: prevent moving the player while he's attacking 
        Move();

        // Animate the player.
        Animating();

        TimeUntilRun();

    }

    void TimeUntilRun()
    {
        bool IsWalking = h != 0f || v != 0f && !IsInWater();

        if(IsWalking && timeUntilRuns >= 0)
        {
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
        // Set the movement vector based on the axis input.
        /* movement.Set(h, 0f, v);

         // Normalise the movement vector and make it proportional to the speed per second.
       movement = (movement.normalized) * Speed * Time.deltaTime;

         // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);*/

        Speed = timeUntilRuns <= 0 ? runSpeed : initSpeed;


        float movement = Speed * dir.magnitude;
        //Debug.Log(transform.forward * movement) ;
        transform.Translate(transform.forward * movement * Time.deltaTime, Space.World);
        //playerRigidbody.AddForce(transform.forward * movement * Time.deltaTime, ForceMode.Impulse);
        //playerRigidbody.velocity = transform.forward * movement * Time.deltaTime;


    }



    void Turning()
    {
        rotation.Set(h, v);
        dir = rotation.normalized;

        if(dir != Vector2.zero)
        {
            float targetRot = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + cameraTrans.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRot, ref rotationSpeed, 0.15f);
        }
        /*rotation.Set(h, 0f, v);

        if (rotation != Vector3.zero)
        {
            targetRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), 0.15F);
            transform.rotation = targetRotation;
        }*/

    }


    void CheckForFall()
    {
        
        if (!IsGrounded())
        {
            //calculate the distance between our current height and the height we were in the last frame
            lastYTravelDistance = transform.position.y - lastY;

            //if the difference is negative, it means we're descending 
            fallHeight += lastYTravelDistance < 0 ? lastYTravelDistance : 0;

            //cache our current Y position for comparison in the next frame
            lastY = transform.position.y;

            //store that a fall happened
            wasFalling = true;
        }
        else if(IsGrounded() && wasFalling)
        {
            //we check to see if we passed the allowed falling distance and kill the player if necessary
            if (fallHeight <= -deathHeight)
                GetComponent<PlayerHealth>().TakeDamage(100);
            
            //reset fall height since we landed (doesn't matter if we're dead or alive)
            fallHeight = 0;

           
            //checked if player fell to death now prevent repeating
            wasFalling = false;
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
    //Aufnehmen eines Objectes
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
        }
    }

}
