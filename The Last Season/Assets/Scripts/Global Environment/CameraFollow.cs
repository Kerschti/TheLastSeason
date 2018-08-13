using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.


    Vector3 offset;                     // The initial offset from the target.
    Vector3 destination = Vector3.zero;
    //float rotateVel = 0;
    PlayerMovement playerMove;

    public bool rotate = true;

    public float rotationSpeed = 5f;

    float currentYaw = 0f;


    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;

        //playerMove = target.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        currentYaw -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {

        if(rotate)
        {
            Quaternion camAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

            offset = camAngle * offset;
        }

        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;
        //destination = playerMove.TargetRotation * offset;
        //destination += target.position;
        //transform.position = destination;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        //float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, smoothing*Time.deltaTime);
        //transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);

        if(rotate){
            
            transform.LookAt(target);

        }
    }
}
