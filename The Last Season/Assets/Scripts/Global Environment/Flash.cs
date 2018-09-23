using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Flash : MonoBehaviour
{


    public float flashingTime = 0.5f;
    private float waitingTime;
    private Light lightning;
    [HideInInspector]
    public bool notTheEnd = true;

    // Use this for initialization
    void Start()
    {
        Random.InitState(DateTime.Now.Millisecond);
        lightning = GetComponent<Light>();
        lightning.intensity = 0;
        waitingTime = Random.Range(0, 10);
        StartCoroutine(StartFlash());

    }

    private IEnumerator StartFlash()
    {

        while (notTheEnd)
        {
            lightning.intensity = 0;
            yield return new WaitForSecondsRealtime(waitingTime);
            waitingTime = Random.Range(0, 10);
            lightning.intensity = 1;
            yield return new WaitForSeconds(flashingTime);
        }
        lightning.intensity = 0;
        yield break;

    }
}
