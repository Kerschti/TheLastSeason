using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantAppear : MonoBehaviour {

    public GameObject Killerhellephant;     //Instantiate Killerhellephant
    public GameObject fourthReSpawn;        //ReSpawn Point doing by kerstin

    private Vector3 position;               //saves first position for first row of Killerhellephants
    private Vector3 position2;              //saves secound position for secound row of Killerhellephants

    private float c = 1;                    //counter one
    private float c1 = 1;                   //counter two

    void Awake()
    {
        //initialize start position from Hellephant, row1 and row2
        position = new Vector3(25, 2.5f, 55);
        position2 = new Vector3(17, 2, 19);
    }

    /*When player enter trigger, hellephants will appear.
     * 2 whiles positions hellephants at defined position
     * c = amount of hellephants
     */
    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Hellephant");

        if (other.gameObject.tag == "Player")
        {
            fourthReSpawn.SetActive(true);

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
