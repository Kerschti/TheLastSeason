using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantAppear : MonoBehaviour {


    private float timer;
    GameObject killerhellephant;

    int x = 52;
    int y = 3;
    int z = 55;

    int x2 = 14;
    int y2 = 3;
    int z2 = 17;

    Vector3 position;
    private int c = 0;
    private int c2 = 0;

	void Awake () {
        killerhellephant = GameObject.FindGameObjectWithTag("KillerHellephant");
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;

            while (timer == timer % 5f && c < 4)
            {
                position = new Vector3(x, y, z);
                Instantiate(killerhellephant, position, Quaternion.identity);
                c++;
                x = x + 25;
                y = 3;
                z = 55;
                Debug.Log("Jetzt kommt ein neuer Elefant");
            }

            while (timer == timer % 10f && c2 < 4)
            {
                position = new Vector3(x2, y2, z2);
                
                Instantiate(killerhellephant, position, Quaternion.identity);
                c2++;
                x2 = x2 + 25;
                y2 = 3;
                z2 = 17;
                Debug.Log("Jetzt kommt ein neuer Elefant 22");
            }

        }

        
    }
}
