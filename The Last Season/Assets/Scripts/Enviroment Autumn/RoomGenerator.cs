/**using System.Collections;
using Boo.Lang;
using UnityEditor;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
	Vector2 roomSize = new Vector2(4, 4);

	/*Room[,] rooms;

	System.Collections.Generic.List<Vector2> takenPositions = new List<Vector2>();

	int gridSizeX, gridSizeY, numberOfRooms = 5;

	public GameObject roomWithObject;
	// Use this for initialization
	void Start () {
		if (numberOfRooms >= (roomSize.x * 2) * (roomSize.y * 2))
		{
			numberOfRooms = Mathf.RoundToInt((roomSize.x * 2) * (roomSize.y * 2));
		}

		gridSizeX = Mathf.RoundToInt(roomSize.x);
		gridSizeY = Mathf.RoundToInt(roomSize.y);

		CreateRooms();
		SetRoomDoors();
	}
	
	void CreateRooms ()
	{
		rooms = new Room[gridSizeX * 2, gridSizeY * 2];
		rooms[gridSizeX, gridSizeY] = new Room(Vector2.zero, 1);
		takenPositions.Insert(0, Vector2.zero);
		Vector2 checkPos = Vector2.zero;
	}
}

*/