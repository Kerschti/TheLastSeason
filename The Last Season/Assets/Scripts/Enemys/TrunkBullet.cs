using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : MonoBehaviour
{


    protected float Animation;              //Zeit fuer Animation 

    public int attackDamage = 10;           //Eingabe der Attack Auswirkung
    private GameObject player;          
    private PlayerHealth playerhealth; 

    static Vector3 beginP;                  //Position des Ruesselsende
    private Vector3 targetP;                //Position des Spielers


    //Initialization
    void Awake()
    {
        targetP = GameObject.FindWithTag("Player").transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();

        //Kugeln werden nach 8sec zerstört
        Destroy(this.gameObject, 8.0f);
    }

    //When Player in Trigger Funktion Attack() is called
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Attack();
        }
    }

    //Every Update position from parabola will be counted 
    void Update()
    {
        Animation += Time.deltaTime;
        transform.position = Parabola.Parabola1(beginP, targetP, 5f, Animation / 5f);
    }

    //...when player still is alive, attack him
    void Attack()
    {
        if (playerhealth.curHealth > 0)
        {
            playerhealth.TakeDamage(attackDamage);
        }
    }

    //Every diffrent trunkend will be positioned
    public static void SetBeginP(Transform trunkEnd)
    {
        beginP = trunkEnd.position;
    }

 }
