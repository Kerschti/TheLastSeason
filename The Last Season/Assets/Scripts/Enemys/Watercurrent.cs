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

    public Transform[] targetVec;

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

    private GameObject curNum;
    private GameObject curName;

    private string colName;


    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    string OnCollisionEnter(Collision collide)
    {
        Debug.Log("COLLISION NAME: " + collide.gameObject.tag);    //void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                playerMovement.onWayBetweenWaypoints = true;

                countEnterTrigger++;

                Debug.Log("EnterTrigger" + countEnterTrigger);

            }

        }
        return colName = collide.gameObject.tag;

    }




    void Update()
    {
        //step = speed * Time.deltaTime;

        //switch (colName)
        //{
        //    case "cur1":
        //        Debug.Log("In cur1");
        //        targetPos = targetVec[0].transform.position;
        //        Move(targetPos);
        //        break;
        //    case "cur2":
        //        Debug.Log("In cur2");
        //        targetPos = targetVec[1].transform.position;
        //        Move(targetPos);
        //        break;
        //    case "cur3":
        //        targetPos = targetVec[2].transform.position;
        //        Move(targetPos);
        //        break;
        //    case "cur4":
        //        targetPos = targetVec[3].transform.position;
        //        Move(targetPos);
        //        break;
        //    case "cur5":
        //        targetPos = targetVec[4].transform.position;
        //        Move(targetPos);
        //        break;
        //    default:
        //        Debug.Log("Ende");
        //        break;

        //}

        switch (countEnterTrigger)
        {
            case 1:
                Debug.Log("Target 1 im Visier");
                targetPos = targetVec[0].transform.position;

                Move(targetPos);
                break;
            case 2:
                targetPos = targetVec[1].transform.position;
                Move(targetPos);
                break;
            case 3:
                targetPos = targetVec[2].transform.position;
                Move(targetPos);
                break;
            case 4:
                targetPos = targetVec[3].transform.position;
                Move(targetPos);
                break;
            case 5:
                targetPos = targetVec[4].transform.position;
                Move(targetPos);
                break;
            default:
                Debug.Log("Ende");
                break;

        }

    }

    void Move(Vector3 target)
    {
        Debug.Log("Target in Move " + target);
        player.transform.position = Vector3.MoveTowards(player.transform.position, target, step);
        //Debug.Log("PlayerPosition " + player.transform.position);

        if (player.transform.position == target)
        {
            playerMovement.onWayBetweenWaypoints = false;
            Debug.Log("ist am Ende angekommen");
            //countEnterTrigger = 8;

        }


    }

}








