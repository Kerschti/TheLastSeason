using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantAppear : MonoBehaviour {

    GameObject killerhellephant;

    //first row of elephants
    float x1 = 52f;
    float y1 = 3f;
    float z1 = 55f;

    //second row of elephants
    float x2 = 14f;
    float y2 = 3f;
    float z2 = 17f;

    Vector3 position;

    //counter
    private int c = 0;
    private int c2 = 0;

	void Awake () {
        killerhellephant = GameObject.FindGameObjectWithTag("KillerHellephant");
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          
            while ( c < 4)
            {
                position = new Vector3(x1, y1, z1);
                Instantiate(killerhellephant, position, Quaternion.identity);
                c++;
                x1 = x1 + 25;
               
            }

            while ( c2 < 4)
            {
                position = new Vector3(x2, y2, z2);
                Debug.Log("Position von y2 = " + y2);
                Instantiate(killerhellephant, position, Quaternion.identity);
                c2++;
                x2 = x2 + 25;
            }

        }


    }
}
