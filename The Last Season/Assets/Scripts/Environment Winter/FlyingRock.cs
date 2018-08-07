using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRock : MonoBehaviour
{


    //public GameObject rock;
    public GameObject player;
    public Vector3 height;
    public float speed;

    private Collider playerCollider;
    private PlayerMovement playerMove;



    // Use this for initialization
    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        playerMove = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            Debug.Log("entered");
            StartCoroutine(FlyUp());

        }
    }

    private IEnumerator FlyUp()
    {
        yield return new WaitForSeconds(1f);
        transform.Translate(height * speed * Time.deltaTime, Space.World);
        playerMove.enabled = false;
        yield return new WaitForSeconds(1f);
        playerMove.enabled = true;
    }

}
