using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantShoot : MonoBehaviour {


    public Transform trunk;
    public GameObject bullet;

    private GameObject bulletin;

    private Transform player;

    float timer;
    public float timeBetweenAttacks = 1f;

    public bool InRange = false;

    private Transform trunkend;

    public Transform trunkendPos;
    public GameObject trunk1;

    Vector3 trunkposition;
    Vector3 targetP;

    protected float Animation;

    Transform temcross;

    public float elCounter;

    //public TrunkBullet trunkBullet;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        trunkend = GameObject.FindWithTag("TrunkEnd").transform;
        trunk1 = transform.Find("Trunk1").gameObject;
        //trunkendPos = trunk1.transform.Find("TrunkEnd");
    }

    //if player in trigger start shooting
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InRange = true;
            elCounter++;

            //trunkendPos = transform.Find("TrunkEnd");
            trunkendPos = trunk1.transform.Find("TrunkEnd");
            Debug.Log("Player NEAR" + trunkendPos.position);
            TrunkBullet.SetBeginP(trunkendPos);
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

       /* if (bulletin)
        {
            Animation += Time.deltaTime;
            bulletin.transform.position = Parabola.Parabola1(trunkend.position, player.position, 5f, Animation / 5f);
        }
        */
    }
   

    //If player not in trigger stop shooting
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InRange = false;
            //Debug.Log("Der Elefant schießt nicht mehr");

        }
    }

    void Shooting()
    {
        // Reset the timer.
        timer = 0f;

        //Debug.Log("Ist jetzt in shooting drin.");
        bulletin = Instantiate(bullet);
        
        // Instantiate(bullet, temcross.position, temcross.rotation);
       
       
    }


}



