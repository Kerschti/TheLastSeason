using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : MonoBehaviour
{


    protected float Animation;
    public float timeBetweenSwitch = 1f;

    public int attackDamage = 10;
    GameObject player;
    PlayerHealth playerhealth;
    EnemyHealth enemyhealth;
 

    Vector3 beginP;
    Vector3 targetP;

    float timer;
    float pos1;
    float pos2;
    int sec;


    Vector3 startposition;
    Vector3 startposition2;

    float counter;

    void Awake()
    {
        startposition.x = 35;
        startposition.y = 2.5f;
        startposition.z = 55;

        startposition2.x = 16;
        startposition2.y = 2.5f;
        startposition2.z = 19;

        timer = 0.0f;
        pos1 = 5f;
        pos2 = 10f;

        beginP = GameObject.FindWithTag("TrunkEnd").transform.position;
        targetP = GameObject.FindWithTag("Player").transform.position;
        Destroy(this.gameObject, 8.0f);

        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();
        enemyhealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            counter++;
            Debug.Log("Counter TrunkBullett = " + counter);
            Attack();
        }
    }

    void Update()
    {
        //Animation += Time.deltaTime;
        //transform.position = Parabola.Parabola1(startposition, targetP, 5f, Animation / 5f);
        timer += Time.deltaTime;
        //changePos();

    }

    void Attack()
    {

        if(playerhealth.curHealth > 0)
        {
            playerhealth.TakeDamage(attackDamage);
            Debug.Log(playerhealth);
        }
       
    }

    
    //void changePos()
    //{

    //    if (timer <= 5f)
    //        {
    //            Debug.Log("TIMER ! =" + sec);
    //            Animation += Time.deltaTime;
    //            transform.position = Parabola.Parabola1(startposition, targetP, 5f, Animation / 5f);
                

    //        }else if( timer <= 10f)
    //        {
    //            Debug.Log("TIMER 2 =" + sec);
    //            Animation += Time.deltaTime;
    //            transform.position = Parabola.Parabola1(startposition2, targetP, 5f, Animation / 5f);
    //        }
    //    }
    }
