using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int initalHealth = 50;       // The initial health of a enemy.

    private Animator anim;              // Reference to the Animator.
    [HideInInspector]
    public bool isDead = false;         // is the enemy dead?
    [HideInInspector]
    public int currentHealth;           // enemies current health.

    private bool isRhino = false;
    private ParticleSystem particles;
    private EnemyManager enemyManager;
  

    // Use this for initialization
    void Start()
    {
        currentHealth = initalHealth;
        anim = GetComponent<Animator>();
        enemyManager = Object.FindObjectOfType<EnemyManager>();
        //if you are a rhino, this is true.
        if (this.name == "Rhino_PBR") isRhino = true;
        //if you arent a rhino, you have particles.
        if(!isRhino)
        {
            particles = GetComponentInChildren<ParticleSystem>();
        }
    }


    public void TakeDamage(int amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        //play some fluffy particle thing when you are not a rhino.
        if(!isRhino)
        {
            particles.Play();
        }
        // die if you don't have health left.
        if (currentHealth <= 0){
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        anim.SetTrigger("Dead");
        Destroy(gameObject, 3.0f);
        //if the dead enemy isn't a rhino its time to spawn new ones.
        if(!isRhino)
        {
            enemyManager.spawnCount--;
        }
        // if its a Rhino, this game is at the END.
        if(isRhino)
        {
            Object.FindObjectOfType<FinalRoutine>().TheEnd();
        }
        

    }
}
