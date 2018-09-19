using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantAppear : MonoBehaviour {

    public GameObject Killerhellephant;
    

    public Transform trunk;

    Vector3 position2;
    Vector3 position;

    float c = 1;
    float c1 = 1;

    void Awake()
    {
        position.x = 25;
        position.y = 2.5f;
        position.z = 55;

        position2.x = 17;
        position2.y = 2;
        position2.z = 19;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            while (c < 5)
            {
                Instantiate(Killerhellephant, position, Quaternion.identity);
                position.x = position.x + 30;

              

                c++;
            }

            while (c1 < 5)
            {
                Instantiate(Killerhellephant, position2, Quaternion.identity);
                position2.x = position2.x + 40;
                c1++;
            }

        }

    }

    public float GetTrunkPos()
    {
        return 0.0f;
    }

}
