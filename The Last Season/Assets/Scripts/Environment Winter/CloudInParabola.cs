using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudInParabola : MonoBehaviour {

    public Transform end;


    private Vector3 startPos;
    private Vector3 endPos;
    private bool startAnim = false;
    private float animTimer;


    private void Start()
    {
        startPos = transform.position;
        endPos = end.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            startAnim = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            startAnim = true;
        }
    }


    private void Update()
    {
        if(startAnim)
        {
            animTimer += Time.deltaTime;
            //animTimer = animTimer % 7;
            transform.position = Parabola.Parabola1(startPos, endPos, 5f, animTimer / 7f);
        }
    }
}
