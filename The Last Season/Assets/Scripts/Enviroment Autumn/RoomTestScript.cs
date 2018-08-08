using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class RoomTestScript : MonoBehaviour
{

	public Vector2 gridPos;

	public int type;

	public bool left, right, top, bot;

	public RoomTestScript(Vector2 _gridPos, int _type)
	{
		gridPos = _gridPos;
		type = _type;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
