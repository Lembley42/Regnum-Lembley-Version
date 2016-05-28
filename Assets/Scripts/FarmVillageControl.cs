using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FarmVillageControl : MonoBehaviour {

	public string villageName;
	public string villageType;

	public int villageSize;

	public int population;
	public float populationGrowth;

	public int freePopulation;
	public int slavePopulation;

	public float foodStored;
	public float foodStorage;

	public float fertility;
	public float foodProduction;
	public float foodConsumption;

	public GameObject villageOwner;
	public float taxRate;

	public int positionX;
	public int positionY;


	public string[] surrounding;


	void Start()
	{
		SaveSurrounding();
	}

	void SaveSurrounding()
	{
		
	}
}
