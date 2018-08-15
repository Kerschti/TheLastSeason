using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : MonoBehaviour {

	// Use this for initialization
	Rigidbody rb;
	public float BulletSpeed;

	void Start () {
		
		rb = GetComponent<Rigidbody> ();
		rb.AddRelativeForce (0,0,BulletSpeed, ForceMode.Impulse);
	}
	

}
