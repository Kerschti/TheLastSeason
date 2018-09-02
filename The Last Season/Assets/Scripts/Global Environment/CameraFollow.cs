using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.
    public float mouseSensitivity = 10;
    public float distFromTarget = 2;
    public Vector2 PitchMinMax = new Vector2(-40, 85);

    Vector3 rotationSmoothVel;
    Vector3 currentRotation;

    float currentYaw = 0f;
    float pitch;


    void Start()
    {

    }

    void LateUpdate()
    {

        currentYaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, PitchMinMax.x, PitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, currentYaw), ref rotationSmoothVel, smoothing);
        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distFromTarget;

    }

}
