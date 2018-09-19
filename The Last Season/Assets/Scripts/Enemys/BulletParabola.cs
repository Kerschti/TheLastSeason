using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParabola : MonoBehaviour
{

    protected float Animation;
    float counter = 0;

    

    // Update is called once per frame
    void Update()
    {
        Debug.Log("BULLETPARABOLA");
        Animation += Time.deltaTime;
        Animation = Animation % 5f;
        transform.position = Parabola.Parabola1(Vector3.down, Vector3.forward * 10f, 5f, Animation / 5f);

    }
}