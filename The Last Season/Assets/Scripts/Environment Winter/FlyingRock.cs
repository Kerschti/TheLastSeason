using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRock : MonoBehaviour
{


    //public GameObject rock;
    public GameObject player;
    public float height;
    public float speed;
    public Vector3 velocity;
    public GameObject _groundParticles;
    public GameObject holder;

    private Collider playerCollider;
    private PlayerMovement playerMove;
    private Transform firstRock;
    private Vector3 startingPos;
    private Vector3 newPos;
    private ParticleSystem groundParticles;
    private Animation animSecIsle;
    private Animation animCloud;
    private IslandFly animScript;



    private bool hasMoved = false;
    private bool moving = false;
    private bool animationPlays = false;



    // Use this for initialization
    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        playerMove = player.GetComponent<PlayerMovement>();
        groundParticles = _groundParticles.GetComponent<ParticleSystem>();
        animSecIsle = GameObject.Find("SecondIsland").GetComponent<Animation>();
        animCloud = GameObject.Find("WalkCloud").GetComponent<Animation>();
        firstRock = this.transform;
        startingPos = firstRock.position;
        newPos = new Vector3(firstRock.position.x, height, firstRock.position.z);
        animScript = holder.GetComponent<IslandFly>();

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
                animScript.enabled = true;
                animSecIsle.Play();
                animCloud.Play();
                animationPlays = true;

            }

            if (firstRock.position == newPos)
            {
                moving = false;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == playerCollider && !hasMoved)
        {
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

     /*private IEnumerator FlyUp()
     {
         //yield return new WaitForSeconds(1f);
         firstRock.position = Vector3.Lerp(firstRock.position, height, speed * Time.deltaTime);
         hasMoved = true;
         //playerMove.enabled = false;
         yield return new WaitForSeconds(0.5f);
         //playerMove.enabled = true;
     }*/

}
