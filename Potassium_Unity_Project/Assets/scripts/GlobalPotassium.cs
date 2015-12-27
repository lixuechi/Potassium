using UnityEngine;
using System.Collections;

public class GlobalPotassium : MonoBehaviour {

	public static bool isOrangePresent = false;
	public static Transform orangeTransform;
	public static bool isTired = false;
	public static int hpValue = 100;
	private static float hpValueFloat = 100f;

	void Start () {
	
	}
	
	void Update () {
		
		hpValueFloat -= 0.005f;
		hpValue = (int)hpValueFloat; 

		if(hpValue <= 30)
		{
			isTired = true;
		}

	}
}
