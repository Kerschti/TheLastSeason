using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickAtk : MonoBehaviour {

    public int amount = 20;                     // the amount of damage the player does.
   
    private void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.CompareTag("Fightable"))
        {
            // if the other GameObject is an Enemy, damage it.
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(amount);
        }
    }

}
