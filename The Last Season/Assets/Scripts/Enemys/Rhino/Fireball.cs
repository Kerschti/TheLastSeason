using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    Rigidbody rb;                           //save rigidbody 
    public float Fireballspeed;             //speed of fireball

    public int attackDamage = 10;           //Eingabe der Attack Auswirkung
    private GameObject player;              //to get player position
    private PlayerHealth playerhealth;      //to get player health

    private Vector3 targetP;                //Position des Spielers

    // initialization
    void Awake()
    {
         targetP = GameObject.FindWithTag("Player").transform.position;
         player = GameObject.FindGameObjectWithTag("Player");
         playerhealth = player.GetComponent<PlayerHealth>();
        //Destroy fireball after 8 secs
         Destroy(this.gameObject, 8.0f);
     }

    // initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, Fireballspeed, ForceMode.Impulse);
        Attack();

    }

    //Attack enter will reduce player health
    void Attack()
    {
        if (playerhealth.curHealth > 0)
        {
            playerhealth.TakeDamage(attackDamage);
        }
    }


}




