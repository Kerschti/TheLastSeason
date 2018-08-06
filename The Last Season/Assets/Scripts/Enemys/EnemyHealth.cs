using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int initalHealth = 50;

    private int currentHealth;
    private Animator anim;
    [HideInInspector]
    public bool isDead;




    // Use this for initialization
    void Start()
    {
        currentHealth = initalHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        Debug.Log("Health of Enemy:" + currentHealth);
        if (currentHealth <= 0){
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        anim.SetTrigger("Dead");

        Destroy(gameObject, 3.0f);

    }
}
