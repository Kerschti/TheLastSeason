using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : MonoBehaviour
{

    // Use this for initialization
    public float BulletSpeed;
    protected float Animation;

    Vector3 beginP;
    Vector3 targetP;

    void Start()
    {

        beginP = GameObject.FindWithTag("TrunkEnd").transform.position;
        targetP = GameObject.FindWithTag("Player").transform.position;
        Destroy(this.gameObject, 8.0f);
    }

    void Update()
    {
        Debug.Log("Jetzt sollte die Parabel kommen");
        Animation += Time.deltaTime;
        transform.position = Parabola.Parabola1(beginP, targetP, 5f, Animation / 5f);
        Debug.Log("Parabel ist fertig aufgebaut");
    }


}