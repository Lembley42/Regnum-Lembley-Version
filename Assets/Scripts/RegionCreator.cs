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


	private int numberOfRegions = 1;


	void Start () 
	{
		CreateRegions();
	}
	
	void CreateRegions()
	{
		for(int i = 0; i < numberOfRegions; i++)
		{
			var currRegion = GameObject.CreatePrimitive(PrimitiveType.Quad);
			currRegion.GetComponent<Transform>().localScale += new Vector3(1000,1000,1);
			var regionPositionX = Mathf.FloorToInt(i%(Mathf.Sqrt(numberOfRegions)));
			var regionPositionY = Mathf.FloorToInt(i/(Mathf.Sqrt(numberOfRegions)));
			currRegion.name = ("" + regionPositionX + "," + regionPositionY);
			currRegion.transform.SetParent(transform);
			currRegion.AddComponent<TileManagement>();
			currRegion.GetComponent<TileManagement>().regionPositionX = regionPositionX;
			currRegion.GetComponent<TileManagement>().regionPositionY = regionPositionY;
			GetComponent<WorldInfo>().regionCoords[regionPositionX, regionPositionY] = currRegion;
			currRegion.transform.position = new Vector2(regionPositionX*100, regionPositionY*100);
		}
	}
}

