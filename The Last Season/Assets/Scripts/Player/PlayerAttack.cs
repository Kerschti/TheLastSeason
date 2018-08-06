using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float timeBetweenAttacks = 0.15f;

    private Animator anim;
    private float timer;
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

        if(Input.GetKeyDown(KeyCode.F) && timer >= timeBetweenAttacks)
        {
            Fight();
        }
        if(timer >= timeBetweenAttacks * animTime)
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
