using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // Create a layer mask for the floor layer.
        Debug.Log(Object.FindObjectOfType<EnemyManager>());
        floorMask = LayerMask.GetMask("Floor");
        waterMask = LayerMask.GetMask("Water");
        spawnAreaMask = LayerMask.GetMask("SpawnArea");
        col = GetComponent<CapsuleCollider>();
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cameraTrans = Camera.main.transform;
        enemyManager = Object.FindObjectOfType<EnemyManager>();
        
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
        if(SceneManager.GetActiveScene().ToString().Equals("MeltemsScene"))
        {
            MakeEnemiesSpawn();
        }
      


    }



    void FixedUpdate()

    {

        // Move the player around the scene.
        //TODO: prevent moving the player while he's attacking 
        if(!onWayBetweenWaypoints)
        {
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
        if(IsInSpawnArea() && enemyManager.enabled == false)
        {
            Debug.Log("THEY ARE COMING");
            enemyManager.enabled = true;
        }
        else if (!IsInSpawnArea() && enemyManager.enabled == true)
        {
            Debug.Log("GET SOME REST?");
            enemyManager.enabled = false;
        }
    }

    void TimeUntilRun()
    {
        //Tanja Value of IsInWater
        bool inWater = IsInWater();

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

    public bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                                                                   col.bounds.min.y,
                                                                   col.bounds.center.z),
                                    col.radius * 1.2f, floorMask);
    }

    public bool IsInWater()
    {

        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                                                                  col.bounds.min.y,
                                                                  col.bounds.center.z),
                                    col.radius * 1.2f, waterMask);
    }

    bool IsInSpawnArea()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                                                                col.bounds.min.y,
                                                                col.bounds.center.z),
                                    col.radius * 1.2f, spawnAreaMask);
    }

    //void Force(bool forceTrue)
    //{
    //    if (forceTrue)
    //    {
    //        Vector3 direction = playerRigidbody.transform.position - transform.position;

    //        playerRigidbody.AddForce(transform.forward*100);

    //        Debug.Log("Player sollte jetzt schneller sein");
    //    }
    //}

     void Move()

    {

        // Set speed based on direction & run or walkspeed, based on how long he moved.
        speedSetting.Speed = (timeSetting.timeUntilRuns <= 0 ? speedSetting.runSpeed : initSpeed) * dir.magnitude;

        // Smoothen speedgain over time.
        curSpeed = Mathf.SmoothDamp(curSpeed, speedSetting.Speed, ref SpeedVelocity, timeSetting.smoothTime);

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
            //playerRigidbody.AddForce(new Vector3(0, 2, 0) * speedSetting.jumpForce, Fo⁄rceMode.Impulse);
        }


    public void Animating()
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
    
    
    //Aufnehmen eines Objectes
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
        }
    }
}
