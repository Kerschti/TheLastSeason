using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParabola : MonoBehaviour
{

    protected float Animation;

    // Update is called once per frame
    void Update()
    {
        Animation += Time.deltaTime;
        Animation = Animation % 5f;
        transform.position = Parabola.Parabola1(Vector3.zero, Vector3.forward * 10f, 5f, Animation / 5f);
    }
}