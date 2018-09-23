using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class PlayerMovement : MonoBehaviour
{

    /*
     * Script for moving and animating the player as he moves around the world.
     * 
     * Inspired by a PlayerMovement script I wrote
     * earlier for an other project and https://youtu.be/BBS2nIKzmbw 
     * 
     * @author Kerstin Dittmann
     * 
     */

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
    private int spawnAreaMask;                  // A layer for the Area in which Enemys will spawn.
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
    EnemyManager enemyManager;
    [HideInInspector]
    public bool onWayBetweenWaypoints = false;

    public SpeedSetting speedSetting = new SpeedSetting();
    public TimeSetting timeSetting = new TimeSetting();

    bool inWater;

    public void Awake()
    {
        // Create a layer mask for each layer.
        floorMask = LayerMask.GetMask("Floor");
        waterMask = LayerMask.GetMask("Water");
        spawnAreaMask = LayerMask.GetMask("SpawnArea");
        // Get Collider of player.
        col = GetComponent<CapsuleCollider>();
        // Get players Rigidbody.
        playerRigidbody = GetComponent<Rigidbody>();
        // Get players Animator.
        anim = GetComponent<Animator>();
        // Reference to the Camera.
        cameraTrans = Camera.main.transform;
        // Find the script of EnemyManager
        enemyManager = Object.FindObjectOfType<EnemyManager>();

        // Save the initioal Time & Speed settings for later.
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


        // Turn the player.
        Turning();

        // Check if Enemies should be spawning.
        if (SceneManager.GetActiveScene().ToString().Equals("MeltemsScene"))
        {
            MakeEnemiesSpawn();
<<<<<<< HEAD
        }



=======
        }

>>>>>>> 824290e437aa15c891766cd90d95309c81d295b5
    }
    


    // Runs later than Update
    void FixedUpdate()

    {

        // Move only when not being in current.
        if (!onWayBetweenWaypoints)
        {
            // Move the player around the scene.
            Move();

            //Jump if desired.
            Jump();

        }


        // Animate the player.
        Animating();

        // Calculate Time.
        TimeUntilRun();

    }


    void MakeEnemiesSpawn()
    {
        //If the player is in spawn area enemys are being spawned.
        if (IsInSpawnArea() && enemyManager.enabled == false)
        {
            enemyManager.enabled = true;
        }
        //If not, not.
        else if (!IsInSpawnArea() && enemyManager.enabled == true)
        {
            enemyManager.enabled = false;
        }
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

            //Start force

        }
    }


    //Returns true if the player collides with Floor Layer.
    public bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                                                                   col.bounds.min.y,
                                                                   col.bounds.center.z),
                                    col.radius * 1.2f, floorMask);
    }

    //Returns true if player collides with Water Layer.
    public bool IsInWater()
    {

        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                                                                  col.bounds.min.y,
                                                                  col.bounds.center.z),
                                    col.radius * 1.2f, waterMask);
    }

    //Returns true if player collides with Spawn Area Layer.
    bool IsInSpawnArea()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                                                                col.bounds.min.y,
                                                                col.bounds.center.z),
                                    col.radius * 1.2f, spawnAreaMask);
    }


    void Move()
    {

        // Set speed based on direction & run or walkspeed, based on how long he moved.
        speedSetting.Speed = (timeSetting.timeUntilRuns <= 0 ? speedSetting.runSpeed : initSpeed) * dir.magnitude;

        // Smoothen speedgain over time.
        curSpeed = Mathf.SmoothDamp(curSpeed, speedSetting.Speed, ref SpeedVelocity, timeSetting.smoothTime);

        // Translate Player forward by speed. 
        transform.Translate(transform.forward * curSpeed * Time.deltaTime, Space.World);

    }



    void Turning()
    {
        //Set rotation Vector to input
        rotation.Set(h, v);
        // Normalize rotation Vector to get direction.
        dir = rotation.normalized;

        if (dir != Vector2.zero)
        {
            // Calculate players rotation by radians. Add CamRotation, so player is going forward according to camera rotation.
            float targetRot = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + cameraTrans.eulerAngles.y;
            // Set transforms rotation smoothly.
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRot, ref speedSetting.rotationSpeed, 0.15f);
        }

    }

    void Jump()
    {
        // When player is Grounded...
        if (IsGrounded())
        {
            //the vertical Verlocity should be zero.
            verticalVelocity = 0;
            //if player is Grounded and Space Bar is pressed...
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //set the vertical verlocity to defined jumpForce.
                verticalVelocity = speedSetting.jumpForce;
            }
        }
        //if Player is not Grounded...
        else
        {
            //let the player come back to earth with defined Acceleration.
            verticalVelocity -= speedSetting.downwardAccel;
        }

        //set jumpVector according to whatever is the case
        Vector3 jumpVector = new Vector3(0, verticalVelocity, 0);

        //and move player towards that direction.
        playerRigidbody.velocity = transform.TransformDirection(jumpVector);
        //playerRigidbody.AddForce(new Vector3(0, 2, 0) * speedSetting.jumpForce, Fo⁄rceMode.Impulse);
    }


    public void Animating()
    {
        //store if player is moving and not in water.
        bool IsWalking = h != 0f || v != 0f && !IsInWater();
        //store if player should be running
        float running = timeSetting.timeUntilRuns <= 0 ? 1f : 0.5f;

        //set swim animation if player is in Water
        anim.SetBool("IsInWater", IsInWater());


        //set jump animation.
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
            //set animation according to speed of player.
            anim.SetFloat("SpeedPerc", running);

        }

        else if (!IsWalking)
        {
            //set animation if player is idle.
            anim.SetFloat("SpeedPerc", 0);
        }



    }


    //@Meltem Aufnehmen eines Objectes
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
        }
    }
}
