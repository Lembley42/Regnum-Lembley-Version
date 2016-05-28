using UnityEngine;
using System.Collections;

public class WorldInfo : MonoBehaviour {

	public int currCameraPositionX;
	public int currCameraPositionY;


	public GameObject [,] regionCoords = new GameObject[100,100];

	void Start () 
	{

	}
	
	void Update()
	{
		var cameraPosition = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);

		currCameraPositionX = Mathf.FloorToInt(cameraPosition.x/10);
		currCameraPositionY = Mathf.FloorToInt(cameraPosition.y/10);
	}
}
	