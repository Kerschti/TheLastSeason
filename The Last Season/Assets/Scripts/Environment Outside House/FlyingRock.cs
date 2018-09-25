using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRock : MonoBehaviour
{

    public GameObject player;               //reference to player.       
    public float height;                    // height which to fly.
    public float speed;                     //speed at which to go.
    public Vector3 velocity;                //the velocity
    public GameObject _groundParticles;     //Particle system which to play 
    // The diverse objects to be set active when player enters the firstIsland.
    public GameObject flyingIsland;
    public GameObject spawnPoint;
    public GameObject rhinoPrefab;

    private Collider playerCollider;        // Reference to playerCollider.
    private Transform firstRock;
    private Vector3 newPos;
    private ParticleSystem groundParticles;
    //booleans to determine what to do next.
    private bool hasMoved = false;
    private bool moving = false;
    private bool animationPlays = false;



    // Use this for initialization
    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        groundParticles = _groundParticles.GetComponent<ParticleSystem>();
        firstRock = this.transform;
        newPos = new Vector3(firstRock.position.x, height, firstRock.position.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            //firstRock.position = Vector3.Lerp(firstRock.position, newPos, speed * Time.deltaTime);
            firstRock.position = Vector3.SmoothDamp(firstRock.position, newPos, ref velocity, speed);
            if(!animationPlays)
            {
                //if nothing is instantiated yet, instantiate the rest of the parcour.
                spawnPoint.SetActive(true);
                Instantiate(flyingIsland, flyingIsland.transform.position, flyingIsland.transform.rotation);
                Instantiate(rhinoPrefab, rhinoPrefab.transform.position, rhinoPrefab.transform.rotation);
                animationPlays = true;

            }

            if (firstRock.position == newPos)
            {
                //stop moving if the Island reached final Position.
                moving = false;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == playerCollider && !hasMoved)
        {
            //Start moving, play sound and ground particles when player enters the Island.
            FindObjectOfType<AudioManager>().Play("FirstIsland");
            collision.collider.transform.SetParent(transform);
            moving = true;
            groundParticles.Play();

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider == playerCollider)
        {

            collision.collider.transform.SetParent(null);
        }
    }

}
