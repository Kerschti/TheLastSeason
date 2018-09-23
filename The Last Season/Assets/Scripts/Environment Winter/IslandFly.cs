using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandFly : MonoBehaviour {

    public float speed;                 //used for setting speed of Island.
    public Transform ThirdIsland;       //finding the Transform which should be moved.
    public float height;                // setting height to wich to move Island.

    private Vector3 newPosThirdI;       // Vector3 of new Position.
    private Vector3 oldPosThirdI;       // Vector3 of initial Position.
    private bool firstPos = true;       // storing the postion Island is at.

    public Vector3 velocity;


	void Start () {
        //initializing the Vectors between which to interpolate.
        newPosThirdI = new Vector3(ThirdIsland.position.x, height, ThirdIsland.position.z);
        oldPosThirdI = ThirdIsland.position;
	}

	void Update () {
        AnimateThirdIsland();

	}

    void AnimateThirdIsland()
    {
        // if Island is at first position...
        if(firstPos)
        {
            //Smoothly go to second position.
            ThirdIsland.position = Vector3.SmoothDamp(ThirdIsland.position, newPosThirdI, ref velocity, speed);
            if(ThirdIsland.position == newPosThirdI)
            {
                firstPos = false;
            }
        } 
        // if Island is at second Position...
        else if (!firstPos)
        {
            //Smoothly go to first Position.
            ThirdIsland.position = Vector3.SmoothDamp(ThirdIsland.position, oldPosThirdI, ref velocity, speed);
            if(ThirdIsland.position == oldPosThirdI)
            {
                firstPos = true;
            }
        }
           
      
    }


}
