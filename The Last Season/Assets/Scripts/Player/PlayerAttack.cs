using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float timeBetweenAttacks = 0.15f;        // Time between each of the players attacks.

    private Animator anim;                  
    private float timer;                            // timer to count if player should be attacking again.
    private float animTime = 1.2f;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // if F-Key was pressed and timer is greater than timeout.
        if (Input.GetKeyDown(KeyCode.F) && timer >= timeBetweenAttacks)
        {
            //fight!!!!
            Fight();
        }
        if (timer >= timeBetweenAttacks * animTime)
        {
            anim.SetBool("IsFighting", false);

        }
    }

    void Fight()
    {
        timer = 0f;
        anim.SetBool("IsFighting", true);

    }
}
