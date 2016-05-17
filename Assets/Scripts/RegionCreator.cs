using UnityEngine;
using System.Collections;
using System.IO;

public class RegionCreator : MonoBehaviour {

	public GameObject pfbGrassTile;
	public GameObject pfbForestTile;
	public GameObject pfbGrainTile;
	public GameObject pfbCenterTile;
	public GameObject pfbHouseTile;
	//Holds Tiles


	private int numberOfRegions = 625;
	//Sets amount of Regions. Needs to be n² (here : 25²)


	void Start () 
	{
		CreateRegions();
	}
	
	void CreateRegions()
	{
		for(int i = 0; i < numberOfRegions; i++)
		{
			var currRegion = new GameObject("Region" + i);
			currRegion.transform.SetParent(transform);
			currRegion.AddComponent<RegionInfo>();
			//Creates n² Regions, sets them as Child of "World" and adds the RegionInfo Component
			currRegion.GetComponent<RegionInfo>().regionPositionX = Mathf.FloorToInt(i%(Mathf.Sqrt(numberOfRegions)));
			//Determines x value of the regions position. For the 77th with 25^2 region for example :
			// 77%25 = 2 (25 goes in 77 3x clean, with 2(!) leftover). X position of the region is therefore 2.
			currRegion.GetComponent<RegionInfo>().regionPositionY = Mathf.FloorToInt(i/(Mathf.Sqrt(numberOfRegions)));
			//Determines y value of the regions position. For the 77th with 25^2 region for example : 
			// 77/25 = 3,08 - rounded down (-> Mathf.FloorToInt) 3. The y position of the region is therefore 3.
			// Overall it is (2,3).
			GetComponent<WorldInfo>().regionCoords[Mathf.FloorToInt(i%(Mathf.Sqrt(numberOfRegions))), Mathf.FloorToInt(i/(Mathf.Sqrt(numberOfRegions)))] = currRegion;
			//Registers the region into the appropiate (see above) position into the regionCoords (see WorldInfo) for general acess where each region is located.
		}
	}
}

