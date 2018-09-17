using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantAppear : MonoBehaviour {

    public GameObject Killerhellephant;
    public Transform Spawnpoint;
    Vector3 position;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           // Instantiate(Killerhellephant, Spawnpoint.position, Spawnpoint.rotation );

            position.x = 55;
            position.y = 3;
            position.z = 36;

            Instantiate(Killerhellephant, position, Quaternion.identity);

            // createHellephant();
        }

    }

    //void createHellephant()
    //{
           
    //    Instantiate(Killerhellephant, position, Spawnpoint.rotation);

    //}

}
