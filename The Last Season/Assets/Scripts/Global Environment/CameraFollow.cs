using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.
    public float mouseSensitivity = 10; //The Mousesensitivity at witch player can tilt camera.
    public float distFromTarget = 2;    //Distance of camera from player.
    public Vector2 PitchMinMax = new Vector2(-40, 85);  //the minimum and maximum Pitch of camera.

    Vector3 rotationSmoothVel;
    Vector3 currentRotation;

    float currentYaw = 0f;
    float pitch;



    void LateUpdate()
    {
        // Get the desired yaw of camera.
        currentYaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        // Get the desired pitch of camera.
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        // Clamp pitch to min/max values.
        pitch = Mathf.Clamp(pitch, PitchMinMax.x, PitchMinMax.y);

        // Smoothly change Rotation according to the measured ptich/yaw.
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, currentYaw), ref rotationSmoothVel, smoothing);

        // Set the eulerAngles of cam according to Rotation.
        transform.eulerAngles = currentRotation;

        // follow the player as he saves the world.
        transform.position = target.position - transform.forward * distFromTarget;

    }

}
