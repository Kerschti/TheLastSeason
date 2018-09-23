using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int initalHealth = 50;
    
    


    private Animator anim;
    [HideInInspector]
    public bool isDead = false;
    [HideInInspector]
    public int currentHealth;

    private bool isRhino = false;
    private ParticleSystem particles;
  



    // Use this for initialization
    void Start()
    {
        currentHealth = initalHealth;
        anim = GetComponent<Animator>();
        if (this.name == "Rhino_PBR") isRhino = true;
        
        if(!isRhino)
        {
            particles = GetComponentInChildren<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        if(!isRhino)
        {
            particles.Play();
        }

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
        if(isRhino)
        {
            Object.FindObjectOfType<FinalRoutine>().TheEnd();
        }
        

    }
}
