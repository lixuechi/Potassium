using UnityEngine;
using System.Collections;

public class GlobalPotassium : MonoBehaviour {

	public static bool isOrangePresent = false;
	public static Transform orangeTransform;
	public static bool isTired = false;
	public static int hpValue = 100;
	private static float hpValueFloat = 100f;
	public static bool isHackOn = true;
	public static int time_speed = 1;

	void Start () {
	
	}
	
	void Update () {
		
		if(hpValue >= 0)
		{
			hpValueFloat -= 0.005f * time_speed;
		}
		
		hpValue = (int)hpValueFloat; 

		if(hpValue <= 30)
		{
			isTired = true;
		}

	}
}
