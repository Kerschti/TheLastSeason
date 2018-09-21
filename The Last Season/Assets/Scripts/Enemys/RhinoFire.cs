using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoFire : MonoBehaviour {

    Transform player;
    public Transform toung;
    public GameObject fireball;
    Vector3 toungPos;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;

    }

    void Update()
    {
        transform.LookAt(player);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine("Shooting");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StopCoroutine("Shooting");
        }
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            Instantiate(fireball, toung.position, toung.rotation);

            Debug.Log("Toung position: "+toung.position);

            yield return new WaitForSeconds(2);
        }

    }
}






