using UnityEngine;
using System.Collections;

public class RegionInfo : MonoBehaviour {


	public GameObject[,] regionMap = new GameObject[10,10];
	//Holds the Tiles belonging to the Region, based in an 2D Array.

	public GameObject[,] regionTiles = new GameObject[10,10];
	//Holds the Tile GameObjects when they're active, so you can destroy them without clearing the entire region's map.

	public GameObject[] tileList = new GameObject[4];
	//Holds the Tiles so you can randomize around them.

	public int regionPositionX;
	public int regionPositionY;
	//Holds the (x,y) position of the region. Infused by "RegionCreator")

	public bool visible;
	//Whether the regional map should be visible

	public bool drawn;
	//Whether the regional map is already visible

	void Start ()
	{
		//Types of tiles
		tileList[0] = transform.parent.GetComponent<RegionCreator>().pfbGrassTile;	
		tileList[1] = transform.parent.GetComponent<RegionCreator>().pfbForestTile;		

		for(int x = 0; x < 10; x++)
		{
			for(int y = 0; y < 10; y++)
			{
				//The 2nd number should equal the amount of different tiles
				var random = Random.Range(0, 2);
				regionMap[x,y] = tileList[random];
			}
		}
		//Cycle 10x10. then create randomly a Tile and put it into the regionMap 2D Array.
		// Double for-loop makes it go like this : x = 0, y = 0 | x = 0, y = 1, x = 0, y = 2, ... until y = 10, then x = 1, y = 0 | x = 1, y = 1,.....

	}


	void Update()
	{
		if(visible == true && drawn == false)
		//If it should be visible but isnt yet...
		{
			Draw();
			//make it visible
		}
		else if(visible == false && drawn == true)
		{
			//If it shouldnt be visible but is
			for(int x = 0; x < 10; x++)
			{
				for(int y = 0; y < 10; y++)
				{
					Destroy(regionTiles[x,y]);
				}
			}
			drawn = false;
			//Cycle through all active Tiles and destroy them. Then set to not visible anymore.
		}
		if(visible == true && drawn == true)
		//If it is visible and should be...
		{
			CheckWhetherStillUpToDate();
			//Check whether that is still the case
		}
	}

	void Draw()
	{
		for(int x = 0; x < 10; x++)
		{
			for(int y = 0; y < 10; y++)
			{
				var curr = Instantiate(regionMap[x,y], new Vector3(regionPositionX*10+x, regionPositionY*10+y), Quaternion.identity) as GameObject;
				regionTiles[x,y] = curr;
			}
		}
		drawn = true;
		//Cycle through all Tiles and Instantiates GameObjects out of them. 
		//Position should be based on the position of the local regionMap + (the current region Position in the region Grid * 10 (the amount of tiles widht / length per Region))
	}

	void CheckWhetherStillUpToDate()
	{
		var worldInfo = transform.parent.GetComponent<WorldInfo>();
		if(regionPositionX > worldInfo.currCameraPositionX-2 || regionPositionX < worldInfo.currCameraPositionX+2 || regionPositionY > worldInfo.currCameraPositionY-2 || regionPositionY < worldInfo.currCameraPositionY+2)
		{
			visible = false;
		}
		//Ask WorldInfo whether the region position in the Region Grid is outside the visbility range of the cameras focus. If so, make whether it should be visible false.
	}
}
