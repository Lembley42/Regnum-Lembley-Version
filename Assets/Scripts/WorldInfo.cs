using UnityEngine;
using System.Collections;

public class WorldInfo : MonoBehaviour {

	public int currCameraPositionX;
	public int currCameraPositionY;


	public GameObject [,] regionCoords = new GameObject[25,25];
	//Holds the regions in an 2D Array based on its XY Value

	void Start () 
	{

	}
	
	void Update()
	{
		var cameraPosition = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
		//Gets and stores the Vector2 of the Main Camera position

		currCameraPositionX = Mathf.FloorToInt(cameraPosition.x/10);
		currCameraPositionY = Mathf.FloorToInt(cameraPosition.y/10);
		//Rounds down the x/y of the Camera position and divides it by 10 (the tile number of a Region to identify what region the Camera is centered on

		for(int x = -2+currCameraPositionX; x < (-2+currCameraPositionX)+5; x++)
		{
			for(int y = -2+currCameraPositionY; y < (-2+currCameraPositionY)+5; y++)
			{
				regionCoords[x,y].GetComponent<RegionInfo>().visible = true;
			}
		}
		//Calls all regions around it on base 25 and turns Boolean visible on true
		/*
		 * Example if the Region looked at would be 4,4 :
		 * 0 1 2 3 4 5 6 7 8 9
		 * 0 1|2-3-4-5-6|7 8 9
		 * 0 1|2 3 4 5 6|7 8 9
		 * 0 1|2 3 4 5 6|7 8 9
		 * 0 1|2 3 4 5 6|7 8 9
		 * 0 1|2-3-4-5-6|7 8 9
		 * 0 1 2 3 4 5 6 7 8 9
		 * */
	}
}
	