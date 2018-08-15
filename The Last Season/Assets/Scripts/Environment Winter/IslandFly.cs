using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandFly : MonoBehaviour {

    public float speed;
    public Transform ThirdIsland;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AnimateThirdIsland();

	}

    void AnimateThirdIsland()
    {
        ThirdIsland.RotateAround(transform.position, new Vector3(1, 0, 0), speed * Time.deltaTime);
    }
}
