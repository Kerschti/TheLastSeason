using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 100;
    public int curHealth;
    private bool damaged;
    private bool dead = false;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        curHealth = health;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {

        damaged = true;

        curHealth -= amount;

        Debug.Log("Health of Player: " + curHealth);

        if(curHealth <=0 && !dead)
        {
            Death();
        }


    }

    void Death()
    {
        dead = true;

        anim.SetTrigger("IsDead");
    }
}
