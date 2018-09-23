using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoldPlayer : MonoBehaviour {

    /*
     * Makes the Player a child of each playerHolder object, for the time he is on the flying Islands.
     * 
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.transform.SetParent(transform);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
