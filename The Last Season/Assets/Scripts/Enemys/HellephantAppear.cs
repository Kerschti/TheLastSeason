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
        position = new Vector3(x, y, z);
        c = 0;
        x = 15;
        y = 3;
        z = 16;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;

            while (timer == timer % 5f && c < 6)
            {
                Debug.Log("Hellephant Appear");
                Instantiate(killerhellephant, position, Quaternion.identity);
                c++;
            }
        }

        
    }
}
