using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{

    public int numObjects = 10;     // Integer value of how many of each trees Object will be spawned.
    public GameObject[] trees;      // GameObject Array of tree GameObjects.
    //float radius;                   


    void Start()
    {
        // Set static Random seed, because we want our trees to be placed at static places.
        Random.InitState(99);
        // Set center of Forest to be the GameObject to which Script is attached.
        Vector3 center = transform.position;

        foreach (GameObject tree in trees)
        {
            for (int i = 0; i < numObjects; i++)
            {
                // Calculate random radius with max value so trees arent placed in a clean circle.
                float radius = Random.value * 50;
                // Calculate position to place tree, in Circle
                Vector3 pos = RandomCircle(center, radius);
                Quaternion rot = Quaternion.LookRotation(center - pos);
                Instantiate(tree, pos, rot);
            }
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        // Calculate random Angle in Circle.
        float ang = Random.value * 360;
        Vector3 pos;
        //Set Values of pos.
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;

    }

}

