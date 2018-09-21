using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickAtk : MonoBehaviour {

    int amount = 20;
   

    private void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.CompareTag("Fightable"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(amount);
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
