using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class RoomTestScript : MonoBehaviour
{
	private float a, b; // xy

	float segHoehe = 5.0f; //height

	float segTiefe = 0.25f;  //depth

	float segBreite = 0.0f;
	
	private bool fixSegmentBreite = true;

	float fixedSegBreite = 5.0f; // Seg width

	private Vector3 erstesSeg = Vector3.zero;
	
	//private Vector3 erstesSeg = erstesSeg.(new Vector3(-5, 0, -5));

	Transform pfad; //path

	public GameObject wallSegPref; //Pfad

	public GameObject CoffeePrefab;

	public GameObject CouchPrefab;

	public GameObject TvPrefab;

	public GameObject CabinetPrefab;

	public GameObject DoorPrefab;
	
	private List<GameObject> wallSegList = new List<GameObject>();

	private bool ersteSeg = true; //firstSegment
	
	
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

		if (fixSegmentBreite)
		{
			segBreite = fixedSegBreite;
		}
	
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
		
		//Coffee Table
		Vector3 tmpCofPos = wallSegList[4].transform.position;
		tmpCofPos = tmpCofPos + new Vector3(-5.44f - tmpCofPos.x, 0f, -1.18f - tmpCofPos.z);
		
		Quaternion tmpCofRot = CoffeePrefab.transform.rotation;
		tmpCofRot = tmpCofRot * Quaternion.Euler(0f, 0f, 0f);
		
		GameObject tmpCoffee = (GameObject)Instantiate(CoffeePrefab, tmpCofPos, tmpCofRot);
		
		//Couch 
		Vector3 tmpCouPos = wallSegList[8].transform.position;
		tmpCouPos = tmpCouPos + new Vector3(2.3f, 0.0f, 0f);
		
		Quaternion tmpCouRot = CouchPrefab.transform.rotation;
		tmpCouRot = tmpCouRot * Quaternion.Euler(1f, 85f, 3f);
		
		GameObject tmpCou = (GameObject)Instantiate(CouchPrefab, tmpCouPos, tmpCouRot);
		
		//Tv 
		Vector3 tmpTvPos = wallSegList[2].transform.position;
		tmpTvPos = tmpTvPos + new Vector3(-10.3f, 0f, 7f);
		
		Quaternion tmpTvRot = TvPrefab.transform.rotation;
		tmpTvRot = tmpTvRot * Quaternion.Euler(0f, 95f, 0f);
		
		GameObject tmpTv = (GameObject)Instantiate(TvPrefab, tmpTvPos, tmpTvRot);
		
		//Cabinet
		Vector3 tmpCabinetPos = wallSegList[6].transform.position;
		tmpCabinetPos = tmpCabinetPos + new Vector3(0f, 0f, -0.5f);
		
		Quaternion tmpCabinetRot = CabinetPrefab.transform.rotation;
		tmpCabinetRot = tmpCabinetRot * Quaternion.Euler(2f, 90f, 3f);
		
		GameObject tmpCabinet = (GameObject)Instantiate(CabinetPrefab, tmpCabinetPos, tmpCabinetRot);
		
		//Door
		Vector3 tmpDoorPrefabPos = wallSegList[5].transform.position;
		tmpDoorPrefabPos = tmpDoorPrefabPos + new Vector3(0f, 0f, -0.5f);
		
		Quaternion tmpDoorPrefabRot = DoorPrefab.transform.rotation;
		tmpDoorPrefabRot = tmpDoorPrefabRot * Quaternion.Euler(0f, 0f, 0f);
		
		GameObject tmpDoorPrefab = (GameObject)Instantiate(DoorPrefab, tmpDoorPrefabPos, tmpDoorPrefabRot);
		
	}
	
		public void CreateWall()
	{
		GameObject wallSeg;

		if (!fixSegmentBreite)
		{
			int segWidth = Random.Range(7, 12);
			segBreite = (float)segWidth;
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

		wallSeg = (GameObject)Instantiate(wallSegPref, pfad.transform.position, pfad.transform.rotation);
		wallSeg.transform.localScale += new Vector3(segBreite, segHoehe, segTiefe);
		wallSegList.Add(wallSeg);
		pfad.Translate(new Vector3(segBreite / 2, 0, 0));
		
	}

	private void Turn(float angle)
	{
		pfad.transform.Translate(new Vector3(0, 0, segTiefe / 2));
		pfad.transform.Rotate(0.0f, angle, 0.0f);
		pfad.transform.Translate(new Vector3(0, 0, segTiefe / 2));
	}
}