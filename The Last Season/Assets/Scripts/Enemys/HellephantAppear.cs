using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantAppear : MonoBehaviour {


    private float timer;
    GameObject killerhellephant;
    int x = 25;
    int y = 10;
    int z = 55;
    Vector3 position;
    private int c = 0;

	void Awake () {
        killerhellephant = GameObject.FindGameObjectWithTag("KillerHellephant");
        position = new Vector3(x,y,z);
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
                x = x + 25;
                Debug.Log("Jetzzt kommt ein neuer Elefant");
            }
        }

        
    }
}
