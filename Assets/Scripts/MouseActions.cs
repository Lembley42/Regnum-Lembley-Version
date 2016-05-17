using UnityEngine;
using System.Collections;

public class MouseActions : MonoBehaviour {

	public float mousePositionX;
	public float mousePositionY;

	Ray ray;
	RaycastHit hit;

	void Start () 
	{

	}
	
	void Update () 
	{
		var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -10f)); 
		mousePositionX = Mathf.FloorToInt(mousePosition.x);
		mousePositionY = Mathf.FloorToInt(mousePosition.y);
		if(Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{

			}
		}
	}



}
