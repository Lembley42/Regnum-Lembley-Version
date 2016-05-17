using UnityEngine;
using System.Collections;

public class DateSystem : MonoBehaviour {

	public static int day = 1;
	public static int month = 1;
	public static int year = 1 ;
	public static int season = 4; //1 = Spring | 2 = Summer | 3 = Autumn | 4 = Winter


	void Start () 
	{
		InvokeRepeating("UpdateDate",0f, 1f);
	}
	
	void UpdateDate () 
	{
		day++;
		DailyActions();
		if(day == 31)
		{
			month++;
			MonthlyActions();
			day = 1;
		}
		if(month == 13)
		{
			year++;
			YearlyActions();
			month = 1;
		}
			
		Debug.Log(day + "." + month + "." + year);
	}


	void DailyActions()
	{
		
	}

	void MonthlyActions()
	{
		
	}

	void YearlyActions()
	{
		
	}
}
