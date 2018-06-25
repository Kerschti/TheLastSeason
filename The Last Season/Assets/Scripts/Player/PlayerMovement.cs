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
    private float smooth = 5f;
    private float animSmooth = 0.1f;


    public float Speed = 7f;

    void Awake()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");

   
        playerRigidbody = GetComponent<Rigidbody>();
 
    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Move the player around the scene.
        //prevent moving the player while he's attacking 

         Move(h, v);

        // Turn the player to face the mouse cursor.
        //Turning();

    }



    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, 0f);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * Speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }



    void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    public Vector3 GetDirVec3(float h, float v)
    {
        Vector3 moveDir = Vector3.zero;

        if (v == 0f)
        {
            if (h < 0f) //-1f
            {
                //Debug.Log("LEFT");
                moveDir.Set(-1f, 0f, 0f);

            }
            else if (h > 0) //1f
            {
                //Debug.Log("RIGHT");
                moveDir.Set(1f, 0f, 0f);
            }
        }
        /*else if (h == 0f)
        {
            if (v < 0f) //-1f
            {
                //Debug.Log("DOWN");
                moveDir.Set(0f, 0f, -1f);
            }
            else if (v > 0) //1f
            {
                //Debug.Log("UP");
                moveDir.Set(0f, 0f, 1f);
            }
        }
        else
        {
            if (h < 0 && v > 0f) //h == -1f && v == 1f
            {
                //Debug.Log("UP LEFT");
                moveDir.Set(-1f, 0f, 1f);
            }
            else if (h > 0f && v > 0f) //h == 1f && v == 1f
            {
                //Debug.Log("UP RIGHT");
                moveDir.Set(1f, 0f, 1f);
            }
            else if (h < 0 && v < 0) //h == -1f && v == -1f
            {
                //Debug.Log("DOWN LEFT");
                moveDir.Set(-1f, 0f, -1f);
            }
            else if (h > 0f && v < 0f) //h == 1f && v == -1f
            {
                //Debug.Log("DOWN RIGHT");
                moveDir.Set(1f, 0f, -1f);
            }
        }*/

        return moveDir;
    }
}
