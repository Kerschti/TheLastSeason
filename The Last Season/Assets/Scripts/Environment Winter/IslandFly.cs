using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandFly : MonoBehaviour {

    public float speed;
    public Transform ThirdIsland;
    public float height;

    private Vector3 newPosThirdI;
    private Vector3 oldPosThirdI;
    private Vector3 velocity;



	// Use this for initialization
	void Start () {
        newPosThirdI = new Vector3(ThirdIsland.position.x, height, ThirdIsland.position.z);
        oldPosThirdI = ThirdIsland.position;
	}
	
	// Update is called once per frame
	void Update () {
        AnimateThirdIsland();

	}

    void AnimateThirdIsland()
    {
        
        if(ThirdIsland.position == oldPosThirdI)
        {
            Debug.Log("Plays");
            ThirdIsland.position = Vector3.SmoothDamp(ThirdIsland.position, newPosThirdI, ref velocity, speed);
        } else if (ThirdIsland.position == newPosThirdI)
        {
            ThirdIsland.position = Vector3.SmoothDamp(ThirdIsland.position, oldPosThirdI, ref velocity, speed);
        }
           
        //ThirdIsland.Translate();
    }


}
