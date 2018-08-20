﻿
using System.Collections; 
using UnityEngine;
/**
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

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]

public class kochband : MonoBehaviour
{

    GameObject turtle;
    public int maxDepth = 4;


    private Mesh mesh;
    private List<Vector3> vertices;
    private List<int> triangles;
    private List<Vector3> normals;

    private float extrudeDepth = 1f;
    private float iteration = 4f;
    private float length = 12f;
    private int zaehler = 0;

    // Use this for initialization
    void Start()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Mein shit";
        vertices = new List<Vector3>();
        triangles = new List<int>();
        normals = new List<Vector3>();

        turtle = new GameObject("Turtle");
        turtle.transform.parent = this.transform;
        Koch(2, 2);
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.normals = normals.ToArray();
    }

    private void Turn(float angle)
    {
        turtle.transform.Rotate(0, 0, angle);
    }

    private void Koch(float length, int depth)
    {
        if (depth == 0)
        {
            Move(length);
        }
        else
        {
            Koch(length / 3, depth - 1);
            Turn(60);
            Koch(length / 3, depth - 1);
            Turn(-120);
            Koch(length / 3, depth - 1);
            Turn(60);
            Koch(length / 3, depth - 1);
        }

    }

    private void Move(float length)
    {
        //old turule position
        vertices.Add(turtle.transform.position); //vtx 0
        vertices.Add(turtle.transform.position + new Vector3(0, 0, extrudeDepth)); // vtx 1
        turtle.transform.Translate(length, 0f, 0f);
        vertices.Add(turtle.transform.position); // vtx 2
        vertices.Add(turtle.transform.position + new Vector3(0, 0, extrudeDepth)); // vtx 3

        Vector3 side1 = vertices[1 + zaehler] - vertices [0 + zaehler];
        Vector3 side2 = vertices[3 + zaehler] - vertices [0 + zaehler];
        Vector3 nrm = Vector3.Cross(side1, side2).normalized;

        normals.Add(nrm);
        normals.Add(nrm);
        normals.Add(nrm);
        normals.Add(nrm);

        triangles.Add(0 + zaehler);
        triangles.Add(1 + zaehler);
        triangles.Add(3 + zaehler);

        triangles.Add(0 + zaehler);
        triangles.Add(3 + zaehler);
        triangles.Add(2 + zaehler);

        triangles.Add(3 + zaehler);
        triangles.Add(1 + zaehler);
        triangles.Add(0 + zaehler);

        triangles.Add(2 + zaehler);
        triangles.Add(3 + zaehler);
        triangles.Add(0 + zaehler);

        zaehler += 4;
    }
}

*/