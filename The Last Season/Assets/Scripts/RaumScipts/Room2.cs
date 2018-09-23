using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class Room2 : MonoBehaviour
{
	//FindObjectOfType<AudioManager>().Play("House");

	private float a, b; // xy

	float segHoehe = 9.0f; //height

	float segTiefe = 0.25f; //depth

	float segBreite = 0.0f;

	private bool fixSegmentBreite = true;

	float fixedSegBreite = 5.0f; // Seg width

	private Vector3 erstesSeg = Vector3.zero;

	//private Vector3 erstesSeg = erstesSeg.(new Vector3(-5, 0, -5));

	//Konstruktionspfad
	Transform pfad;

	//Zuweisungen mit mittels ObjectInsepctor
	public GameObject wallSegPref;

	//Liste die Wandsegmente enthält
	private List<GameObject> wallSegList = new List<GameObject>();

	//Erstes Segment
	private bool ersteSeg = true;


	public void Zufall()
	{
		for (int i = 1; i <= 10; i++)
		{
			a = Random.Range(5.0f, 12.0f);
		}

		for (int i = 1; i <= 10; i++)
		{
			b = Random.Range(5.0f, 12.0f);
		}
	}

	void Start()
	{
		pfad = new GameObject().transform;

		// Verwendet feste Segmentgroesse wenn aktiv
		if (fixSegmentBreite)
		{
			segBreite = fixedSegBreite;
		}

		//Grundriss des Raumes
		CreateWall();
		CreateWall();
		Turn(-90.0f);
		CreateWall();
		CreateWall();
		CreateWall();
		Turn(-90.0f);
		CreateWall();
		CreateWall();
		Turn(-90.0f);
		CreateWall();
		CreateWall();
		CreateWall();

		
	}

	public void CreateWall()
	{
		GameObject wallSeg;

		if (!fixSegmentBreite)
		{
			int segWidth = Random.Range(7, 12);
			segBreite = (float) segWidth;
			Debug.Log("SegmentWidth = " + segWidth);
		}

		if (ersteSeg)
		{
			//pfad.Translate(new Vector3(segBreite / 2, segHoehe / 2, segTiefe / 2));
			pfad.Translate(new Vector3(-5.0f, 0.0f, -5.0f));
		}
		else
		{
			pfad.Translate(new Vector3(segBreite / 2, 0, 0));
		}

		ersteSeg = false;

		Debug.Log("PathPos = " + pfad.position);
		Debug.Log("PathRot = " + pfad.rotation);

		// Neues Wandsegment wird angelegent
		wallSeg = (GameObject) Instantiate(wallSegPref, pfad.transform.position, pfad.transform.rotation);
		// Wandsegement wird scaliert
		wallSeg.transform.localScale += new Vector3(segBreite, segHoehe, segTiefe);
		// Wandsegment wird in Segementliste hinzugefügt
		wallSegList.Add(wallSeg);
		pfad.Translate(new Vector3(segBreite / 2, 0, 0));

	}

	private void Turn(float angle)
	{
		// Halbe Tiefe, nur somit sind die Ecken richtig ausgerichtete sind in der Z-Achse
		pfad.transform.Translate(new Vector3(0, 0, segTiefe / 2));
		// Anwendung der Rotation
		pfad.transform.Rotate(0.0f, angle, 0.0f);
		// Halbe Tiefen, damit Ecken richtig ausgerichtet sind in der X-Achse
		pfad.transform.Translate(new Vector3(0, 0, segTiefe / 2));
	}
}