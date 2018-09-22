using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Watercurrent : MonoBehaviour {

    public GameObject waypoints;
    private GameObject player;
    public int num = 0;

    public float minDist;

    public bool go = false;

    public Transform targetVec;

    //Vector3[] targetVec = new[] { new Vector3(8f, 0.5f, -36f),
    //    new Vector3(-16f, 0.5f, 20f),
    //    new Vector3(0.3f, 0.5f, 12f),
    //    new Vector3(16f, 0.5f, 27f),
    //    new Vector3(-16f, 0.5f, -25f) };

    Vector3 targetPos;
    Vector3 playerPos;

    public float speed;
    public float step;

    public int countEnterTrigger = 0;

    private PlayerMovement playerMovement;


    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindWithTag("Player");

        

        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMovement.onWayBetweenWaypoints = true;

            countEnterTrigger++;

            Debug.Log("EnterTrigger" + countEnterTrigger);

        }

    }

    void Update()
    {
         step = speed * Time.deltaTime;

        switch (countEnterTrigger)
        {
            case 1 :
                Debug.Log("Target 1 im Visier");
                targetPos = targetVec[0];
                
                Move(targetPos);
                break;
            case 2:
                targetPos = targetVec[1];
                Move(targetPos);
                break;
            case 3:
                targetPos = targetVec[2];
                Move(targetPos);
                break;
            case 4:
                targetPos = targetVec[3];
                Move(targetPos);
                break;
            case 5:
                targetPos = targetVec[4];
                Move(targetPos);
                break;
            default:
                Debug.Log("Ende");
                break;
               
        }

    }

    void Move(Vector3 target)
    {
        Debug.Log("TargetPos in Move " + target);

        

        player.transform.position = Vector3.MoveTowards(player.transform.position, target, step);
        Debug.Log("PlayerPosition " + player.transform.position);


    }




    //   case 1: printf("a ist eins\n"); break;
    //case 2: printf("a ist zwei\n"); break;
    //case 3: printf("a ist drei\n"); break;
    //default: printf("a ist irgendwas\n"); break;

    //// Update is called once per frame
    //void Update() {





    //    if (waypoints)
    //    {
    //        //float dist = Vector3.Distance(player.transform.position, waypoints.transform.position);

    //        if (go)
    //        {
    //            if (dist > minDist)
    //            {
    //                //Move();

    //            }
    //            else
    //            {


    //                //waypoints = null;
    //                //go = false;

    //                playerMovement.onWayBetweenWaypoints = false;


    //            }

    //        }
    //    }


    //}

    //public void Move()
    //{
    //    player.transform.LookAt(waypoints.transform.position);
    //    player.transform.position += player.transform.forward * speed * Time.deltaTime;

    //    Debug.Log("IN MOVE");

    //}
}




