/**
using System.Collections; 
using UnityEngine;

	//Einen Raum generieren

public class RoomGenerator : MonoBehaviour
{
	// Vier GameObjekte 2*a 2*b
	
	Vector2 roomSize = new Vector2(4, 4);

	private int Room;
	private int rooms;

	int wallSizeX, wallSizeY, numberOfRooms = 1;

	public GameObject roomWithObject;
	
	// Use this for initialization
	void Start () {
		if (numberOfRooms >= (roomSize.x * 2) * (roomSize.y * 2))	
		{
			numberOfRooms = Mathf.RoundToInt((roomSize.x * 2) * (roomSize.y * 2));
		}

		wallSizeX = Mathf.RoundToInt(roomSize.x);
		wallSizeY = Mathf.RoundToInt(roomSize.y);

		CreateRooms();
		//SetRoomDoors();
	}
	
	void CreateRooms ()
	{
		rooms = new Room[wallSizeX * 2, wallSizeY * 2];
	}
}
*/