using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantAppear : MonoBehaviour {

    public GameObject Killerhellephant;

    private Vector3 position2;
    private Vector3 position;

    private float c = 1;
    private float c1 = 1;

    void Awake()
    {
        //initialize start position from Hellephant, row1 and row2
        position = new Vector3(25, 2.5f, 55);
        position2 = new Vector3(17, 2, 19);
    }

    /*When player enter trigger, hellephants will appear.
     * 2 whiles places  hellephants at defined position
     * c = amount of hellephants
     */
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
}
