using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudInParabola : MonoBehaviour {

    public Transform end;                       // The Point where the Island should finally land.
    public GameObject player;                   // Reference to player.
    public Transform father;                    // Father transform of triggerObject.
    public GameObject parcours;                 // Parcours prefab.
    public GameObject firstIsland;              // reference to first Island of parcours. 


    private Vector3 startPos;                   
    private Vector3 endPos;
    private bool startAnim = false;
    private float animTimer;
    private PlayerHealth playerHealth;

    private void Start()
    {
        // initializing the positions and getting reference to player health script.
        startPos = father.position;
        endPos = end.position;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // making sure player won't die if he comes from cloud and start the animation
            startAnim = true;
            playerHealth.isOnParaCloud = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // blow up the whole parcours after player left it, no need to come back.
            Destroy(firstIsland, 4f);
            Destroy(parcours, 6f);

        }
    }


    private void Update()
    {
        if(player == null)
        {
            // Sometimes player, playerhealth & firstIsland are not found so to be sure, check a second time.
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            if (firstIsland == null)
                firstIsland = GameObject.FindGameObjectWithTag("FirstIsle");
        }

        if(startAnim)
        {
            // let the Island fly in a nice Parabola.
            animTimer += Time.deltaTime;
            father.position = Parabola.Parabola1(startPos, endPos, 5f, animTimer / 7f);

            // when done stop animating.
            if(father.position.y <= 0)
            {
                startAnim = false;
            }

        }
    }
}
