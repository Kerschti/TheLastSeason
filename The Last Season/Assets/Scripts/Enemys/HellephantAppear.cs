using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantAppear : MonoBehaviour {


    //create timer and next hellephant should appear every 5 secs in diffrent positions
    private float timer;
    GameObject killerhellephant;
    int x;
    int y;
    int z;
    Vector3 position;
    int c;

	void Awake () {
        killerhellephant = GameObject.FindGameObjectWithTag("KillerHellephant");
        
        c = 0;
        x = 33;
        z = 52;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;

            while (timer == timer % 5f && c < 3)
            {
                position = new Vector3(x, 3, z);
                Debug.Log("Hellephant Appear");
                Instantiate(killerhellephant, position, Quaternion.identity);
                c++;
                x = x + 10;
                

            }
        }

        
    }
}
