using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Flash : MonoBehaviour
{


    public float flashingTime = 0.5f;            //Time for wich the flash is active.
    private float waitingTime;                  // Time for wich to wait until next Lightning.
    private Light lightning;                    //the Light that does the lightning effect. 
    [HideInInspector]   
    public bool notTheEnd = true;               // bool to determine if flash should stop.

    // Use this for initialization
    void Start()
    {
        // Initialize Random seed.
        Random.InitState(DateTime.Now.Millisecond);
        //Find the light.
        lightning = GetComponent<Light>();
        // set the lights intensity to zero.
        lightning.intensity = 0;
        // initialize the waiting time on random.
        waitingTime = Random.Range(0, 10);

        StartCoroutine(StartFlash());

    }

    private IEnumerator StartFlash()
    {
        // while game is not finished let the lightning flash every not and then. 
        while (notTheEnd)
        {

            lightning.intensity = 0;
            yield return new WaitForSecondsRealtime(waitingTime);
            waitingTime = Random.Range(0, 10);
            lightning.intensity = 1;
            yield return new WaitForSeconds(flashingTime);
        }
        // if the End is there stop lightning
        lightning.intensity = 0;
        yield break;

    }
}
