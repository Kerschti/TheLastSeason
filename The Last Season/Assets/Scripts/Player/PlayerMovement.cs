using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [System.Serializable]
    public class SpeedSetting
    {
        public float jumpForce = 10f;                // Upward force for jumping.
        public float Speed = 3f;                    // moving speed.
        public float runSpeed = 6f;                 // run speed.
        public float rotationSpeed = 75f;           // rotation speed.
        public float downwardAccel = 0.6f;          // Acceleration at which player falls downwards. 
    }

    [System.Serializable]
    public class TimeSetting
    {
        public float smoothTime = 0.1f;             // Smoothtime for smoothing playermovement.
        public float timeUntilRuns = 20;            // Timer until the player runs.
    }


    //private Vector3 movement;                   // The vector to store the direction of the player's movement.
    private Animator anim;                      // Reference to the animator component.
    private Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    private int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    private int waterMask;                      // A layer mask for the Water layer.
    private Vector2 rotation;                   // Vector to store the direction in wich the player should turn.
    private CapsuleCollider col;                // Reference to the Players CapsuleCollider.
    private float h;                            // Stores horizontal input
    private float v;                            // Stores vertical input.
    private float initTime;                     // Stores inital value for timeUntilRuns.
    private float initSpeed;                    // Stores initial value for Speed;
    private float SpeedVelocity;                // Obligatory Velocity value (0) for speedcalculation.
    private float curSpeed;                     // Stores current Speed of player.
    private float verticalVelocity;             // Setting of upward velocity.
    Transform cameraTrans;                      // camera transform.
    Vector2 dir;                                // Vector2 for calculating movement & rotation of player.

    public SpeedSetting speedSetting = new SpeedSetting();
    public TimeSetting timeSetting = new TimeSetting();

    void Awake()
    {
        // Create a layer mask for the floor layer.

        floorMask = LayerMask.GetMask("Floor");
        waterMask = LayerMask.GetMask("Water");
        col = GetComponent<CapsuleCollider>();
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cameraTrans = Camera.main.transform;
        initTime = timeSetting.timeUntilRuns;
        initSpeed = speedSetting.Speed;

    }

    void GetInput()
    {
        // Store the input axes.
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void Update()
    {
        // Get InputAxis.
        GetInput();

<<<<<<< HEAD
        // Turn the player.
        Turning();
=======
        //transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        // Turn the player.
        Turning();
>>>>>>> RraumGenerator
    }



    void FixedUpdate()
<<<<<<< HEAD
    {

        // Move the player around the scene.
        //TODO: prevent moving the player while he's attacking 
        Move();

        //Jump if desired.
        Jump();

        // Animate the player.
        Animating();

        // Calculate Time.
        TimeUntilRun();

=======
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

>>>>>>> RraumGenerator
    }

    void TimeUntilRun()
    {
        // Check if the Player is walking and isn't swimming
        bool IsWalking = h != 0f || v != 0f && !IsInWater();

        if (IsWalking && timeSetting.timeUntilRuns >= 0)
        {
            // Subtract actual Time from timer, if Timer <= 0, trigger running state & stop checking, unless player stopped moving. 
            timeSetting.timeUntilRuns -= Time.deltaTime;

        }
        else if (!IsWalking)
        {
            timeSetting.timeUntilRuns = initTime;
        }
    }

    public bool IsGrounded()
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
<<<<<<< HEAD
    {

        // Set speed based on direction & run or walkspeed, based on how long he moved.
        speedSetting.Speed = (timeSetting.timeUntilRuns <= 0 ? speedSetting.runSpeed : initSpeed) * dir.magnitude;

        // Smoothen speedgain over time.
        curSpeed = Mathf.SmoothDamp(curSpeed, speedSetting.Speed, ref SpeedVelocity, timeSetting.smoothTime);

        // Translate Player forward by speed. 
        transform.Translate(transform.forward * curSpeed * Time.deltaTime, Space.World);
=======
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
>>>>>>> RraumGenerator
        //playerRigidbody.AddForce(transform.forward * movement * Time.deltaTime, ForceMode.Impulse);
        //Debug.Log(movement);
        //playerRigidbody.velocity = transform.forward * movement * Time.deltaTime;

    }



    void Turning()
    {
        rotation.Set(h, v);
        dir = rotation.normalized;

        if (dir != Vector2.zero)
        {
            // Calculate players rotation by radians. Add CamRotation, so player is going forward according to camera rotation.
            float targetRot = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + cameraTrans.eulerAngles.y;
            // Set transforms rotation smoothly.
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRot, ref speedSetting.rotationSpeed, 0.15f);
        }
<<<<<<< HEAD
=======
        /*rotation.Set(h, 0f, v);

        if (rotation != Vector3.zero)
        {
            targetRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), 0.15F);
            transform.rotation = targetRotation;
        }*/
>>>>>>> RraumGenerator

    }

    void Jump()
    {

        if (IsGrounded())
        {
            
            verticalVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                verticalVelocity = speedSetting.jumpForce;
            }
        }
        else
        {
            verticalVelocity -= speedSetting.downwardAccel;
        }

        Vector3 jumpVector = new Vector3(0, verticalVelocity, 0);

        playerRigidbody.velocity = transform.TransformDirection(jumpVector);
    }


    void Animating()
    {
        bool IsWalking = h != 0f || v != 0f && !IsInWater();
        float running = timeSetting.timeUntilRuns <= 0 ? 1f : 0.5f;

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
