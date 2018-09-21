using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    Rigidbody rb;
    public float Fireballspeed;

    public int attackDamage = 10;           //Eingabe der Attack Auswirkung
    private GameObject player;
    private PlayerHealth playerhealth;

    static Vector3 beginP;                  //Position des Ruesselsende
    private Vector3 targetP;                //Position des Spielers

    void Awake()
    {
         targetP = GameObject.FindWithTag("Player").transform.position;
         player = GameObject.FindGameObjectWithTag("Player");
            playerhealth = player.GetComponent<PlayerHealth>();
             Destroy(this.gameObject, 8.0f);
     }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, Fireballspeed, ForceMode.Impulse);
        Attack();

    }

 
    void Attack()
    {
        if (playerhealth.curHealth > 0)
        {
            playerhealth.TakeDamage(attackDamage);
            Debug.Log(playerhealth);
        }
    }


}




