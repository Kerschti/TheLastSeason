using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : MonoBehaviour {

	// Use this for initialization
	Rigidbody rb;
	public float BulletSpeed;
    protected float Animation;

    Vector3 beginP;
    Vector3 targetP;

	void Start () {
		
		rb = GetComponent<Rigidbody> ();
		rb.AddRelativeForce (0,0,BulletSpeed, ForceMode.Impulse);
        beginP = GameObject.FindWithTag("TrunkEnd").transform.position;
        targetP = GameObject.FindWithTag("Player").transform.position;
        //bullet disappear
        //Destroy(this.gameObject, 3.0f);
	}

    void Update()
    {
        Debug.Log("Jetzt sollte die Parabel kommen");
        Animation += Time.deltaTime;
        Animation = Animation % 5f;
        transform.position = Parabola.Parabola1(beginP, targetP * 10f, 5f, Animation / 5f);
        Debug.Log("Parabel ist fertig aufgebaut");
    }
	
 
}
