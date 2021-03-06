﻿using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour 
{
    //wave scale
    public float scale = 1.0f;

	// Update is called once per frame
	void Update () 
    {
        MeshFilter mf = GetComponent<MeshFilter>();

        //create new mesh with x,y,z with Vector3D Array
        Vector3[] vertices = mf.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            //new waves
            vertices[i].y = scale * Mathf.PerlinNoise(Time.time + (vertices[i].x * scale), Time.time + (vertices[i].z * scale));
        }
        //new postion for vertices 
        mf.mesh.vertices = vertices;
	}
}
