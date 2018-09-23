using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoFire : MonoBehaviour {

    Transform player;               //position of player
    public Transform toung;         //position of toung to shoot there the...
    public GameObject fireball;     //fireball
    Animator shouting;              //Animation to shout
    bool triggerEnter;              //checking if Player enter trigger
   
    //Create necessary objects
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        shouting = GetComponent<Animator>();
        shouting.SetTrigger("RhinoNeedFood");
    }

    //every update check, if trigger is entered & shout by true or false
    void Update()
    {
        bool value = IstriggerEnter();
        shouting.SetBool("IsShouting", value);
    }

    //Start shooting fireballs, save bool to false or true for enterTrigger
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggerEnter = true;
            shouting.SetBool("IsWalking", false);
            StartCoroutine("Shooting");
        }
    }

    //save bool to stop shooting and shouting, Pause sound
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggerEnter = false;
            StopCoroutine("Shooting");
            FindObjectOfType<AudioManager>().Pause("Rino");

        }
    }

    //func return value if trigger enter or not
    public bool IstriggerEnter()
    {
        return triggerEnter;
    }


    //Instantiate fireball at toung position & rotation, Play scream sound rino 
    //wait for 6 seconds and repeat if trigger true
    IEnumerator Shooting()
    {
        while (true)
        {
            Instantiate(fireball, toung.position, toung.rotation);
            FindObjectOfType<AudioManager>().Play("Rino");
            yield return new WaitForSeconds(6);
        }

    }
}






