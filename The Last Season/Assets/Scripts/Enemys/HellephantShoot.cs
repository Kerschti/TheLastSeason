using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantShoot : MonoBehaviour {


    public Transform trunk;
    public GameObject bullet;
    private Transform player;

    float timer;
    public float timeBetweenAttacks = 1f;

    public bool InRange = false;

    private Transform trunkend;


    Vector3 trunkposition;
    Vector3 targetP;

    protected float Animation;

    Transform temcross;

    public float elCounter;
    

    

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        targetP = GameObject.FindWithTag("Player").transform.position;

        temcross = GameObject.FindWithTag("TemCross").transform;


        trunkend = GameObject.FindWithTag("TrunkEnd").transform;
    }

    //if player in trigger start shooting
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InRange = true;
            elCounter++;
        }
    }

    void Update()
    {
        transform.LookAt(player);

        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && InRange )
        {
            // ... attack.
            Shooting();
        }

    }
   

    //If player not in trigger stop shooting
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InRange = false;
            Debug.Log("Der Elefant schießt nicht mehr");
        }
    }

    void Shooting()
    {
        // Reset the timer.
        timer = 0f;

        Debug.Log("Ist jetzt in shooting drin.");

        Instantiate(bullet);
       // Instantiate(bullet, temcross.position, temcross.rotation);

    }

    public float GetCounter()
    {
        return elCounter;
    }


}



