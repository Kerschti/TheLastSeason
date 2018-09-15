using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantShoot : MonoBehaviour {


    public Transform trunk;
    public GameObject bullet;
    private Transform player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(player);
    }


    //if player in trigger start shooting
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Shooting");
            
        }

    }

        //If player not in trigger stop shooting
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                StopCoroutine("Shooting");
            }
        }

    //Create new bullet every one second
    IEnumerator Shooting()
        {

            Debug.Log("Elefant schießt");

            while (true)
            {
                Instantiate(bullet, trunk.position, trunk.rotation);
                yield return new WaitForSeconds(1);
            }


        }

    }



