using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Watercurrent : MonoBehaviour {

    private PlayerMovement playerMovement;      //stop it, if player is moving to waypoint
    private GameObject player;                  //to get position
    public Transform[] targetVec;               //Target current point for player

    Vector3 targetPos;                          //temp save variable for TargetVec        

    public float speed;                         //speed from player position to target position
    private float step;                         //temp variable to save speed

    public int countEnterTrigger = 0;           //is trigger enter -> 1 = go, other no
    public GameObject boxtext;                  //to display text "Oh no, I'm in water currents!!"


    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    //If Trigger enter playermovement will stopp and trigger counter set to 1
    //Text will display
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boxtext.SetActive(true);
            playerMovement.onWayBetweenWaypoints = true;
            countEnterTrigger = 1;
        }
    }

    //counting speed and save targetpos and call Move with ist
    void Update()
    {
        step = speed * Time.deltaTime;

        if(countEnterTrigger == 1)
        {
            targetPos = targetVec[0].transform.position;
            Move(targetPos);
        }
    }

    //Move will speed player to target position and set trigger to default number
    void Move(Vector3 target)
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, target, step);

        if (player.transform.position == target)
        {
            playerMovement.onWayBetweenWaypoints = false;
            countEnterTrigger = 42;
            boxtext.SetActive(true);
        }

    }

}








