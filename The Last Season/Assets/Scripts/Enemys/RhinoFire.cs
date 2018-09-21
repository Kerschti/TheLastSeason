using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoFire : MonoBehaviour {

    Transform player;
    public Transform toung;
    public GameObject fireball;
    Animator shouting;
    bool triggerEnter;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        shouting = GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(player);
        bool value = IstriggerEnter();
        Debug.Log("Trigger enter is:" + value);
        shouting.SetBool("IsShouting", value);
    }



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggerEnter = true;
            StartCoroutine("Shooting");


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggerEnter = false;
            StopCoroutine("Shooting");
        }
    }

    bool IstriggerEnter()
    {
        return triggerEnter;
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);

            Instantiate(fireball, toung.position, toung.rotation);
        }

    }
}






