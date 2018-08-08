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
    private float camRayLength = 100f;          // The length of the ray from the camera into the scene.    
    private Vector3 playerToMouse;
    private Vector3 rotation;
    private CapsuleCollider col;
    private float smooth = 5f;
    private float animSmooth = 0.1f;
    private float lastY;
    private float lastYTravelDistance;
    private float fallHeight = 0;
    private float deathHeight = 6;
    private bool wasFalling = false;

    public float jumpForce = 2f;
    public float Speed = 7f;
    public float rotationSpeed = 75f;

    void Awake()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");
        col = GetComponent<CapsuleCollider>();
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        //anim.SetFloat("speedX", Mathf.Abs(h));
        //anim.SetFloat("speedY", Mathf.Abs(v));
       

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);


        }


        //check if player is falling to death
        CheckForFall();


        // Move the player around the scene.
        //prevent moving the player while he's attacking 

        Move(h, v);

        // Turn the player to face the mouse cursor.
        Turning(h, v);

        // Animate the player.
        Animating(h, v);


    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                                                                   col.bounds.min.y,
                                                                   col.bounds.center.z),
                                    col.radius * 1.2f, floorMask);
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);



        // Normalise the movement vector and make it proportional to the speed per second.
       // movement = movement.normalized * Speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        //playerRigidbody.MovePosition(transform.position + movement);
        transform.Translate(movement * Speed * Time.deltaTime, Space.World);

    }



    void Turning(float h, float v)
    {

        rotation.Set(h, 0f, v);

        if (rotation != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), 0.15F);
        }

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

    void Animating(float h, float v)
    {
        bool IsWalking = h != 0f || v != 0f;

        //anim.SetBool("IsWalking", IsWalking);

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
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

    }
}
