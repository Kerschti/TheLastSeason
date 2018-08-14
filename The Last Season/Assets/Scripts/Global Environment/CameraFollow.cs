using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.
    public float mouseSensitivity;
    public float distFromTarget;
    public Vector2 PitchMinMax = new Vector2(-40, 85);

    Vector3 rotationSmoothVel;
    Vector3 currentRotation;

    Vector3 offset;                     // The initial offset from the target.
    Vector3 destination = Vector3.zero;
    //float rotateVel = 0;
    PlayerMovement playerMove;

    public bool rotate = true;

    public float rotationSpeed = 5f;

    float currentYaw = 0f;
    float pitch;


    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;

        //playerMove = target.GetComponent<PlayerMovement>();
    }

    /*void LateUpdate()
    {
        //currentYaw -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        currentYaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(0, currentYaw), ref rotationSmoothVel, smoothing);
        transform.eulerAngles = currentRotation;
        transform.position = target.position + offset;
        transform.LookAt(target);
    }*/

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
