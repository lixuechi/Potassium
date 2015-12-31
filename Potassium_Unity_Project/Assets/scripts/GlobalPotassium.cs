using UnityEngine;
using System.Collections;

public class GlobalPotassium : MonoBehaviour {

	public static bool isOrangePresent = false;
	public static bool isBlueBallPresent = false;
	public static bool isOwlPresent = false;

	public static Transform BlueBall;
	public static Transform Owl;

	public static Transform orangeTransform;
	public static bool isTired = false;
	public static int hpValue = 100;
	private static float hpValueFloat = 100f;
	public static bool isHackOn = true;
	public static int time_speed = 1;

	public const int MOVE_UP = 0;
	public const int MOVE_DOWN = 1;
	public const int MOVE_LEFT = 2;
	public const int MOVE_RIGHT = 3;
	public const int MOVE_IN_CIRCLE = 4;
	public const int MOVE_IN_SQUARE = 5;
	public const int STAY_STATIC = 6;
	public const int MOVE_TO_ORANGE = 7;
	public const int MOVE_TO_BED = 8;
	public const int SLEEP_IN_BED = 9;
	public const int EXIT_BED = 10;
	public const int HIDE_FROM_OWL = 11;

	public static int currMovePattern = 0;

	public static bool isRecoveringHP = false;

	void Start () {
	
	}
	
	void Update () {

		//Debug.Log("is Blue ball present is " + isBlueBallPresent);
		if(isBlueBallPresent && BlueBall != null)
		{
			Debug.Log("blue ball is present and blue ball feed is not null");
			if(Input.GetKey(KeyCode.UpArrow))
			{
				Debug.Log("move the blue ball upward");
				BlueBall.position += new Vector3(0, 0.1f, 0);
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				BlueBall.position += new Vector3(0, -0.1f, 0);
			}
			else if(Input.GetKey(KeyCode.LeftArrow))
			{
				BlueBall.position += new Vector3(-0.1f, 0, 0);
			}
			else if(Input.GetKey(KeyCode.RightArrow))
			{
				BlueBall.position += new Vector3(0.1f, 0, 0);
			}
		}
		
		if(hpValue >= 0 
			&& !(currMovePattern == SLEEP_IN_BED)
			&& !(currMovePattern == MOVE_TO_BED)
			&& !isRecoveringHP)
		{
			hpValueFloat -= 0.005f * time_speed;
			//Debug.Log("Current move pattern is " + currMovePattern);
		}

		if(isRecoveringHP)
		{
			if(hpValue <= 99)
			{
				//hpValue++;
				hpValueFloat += 0.1f;
				Debug.Log("hpValue is " + hpValue);
			}
			else
			{
				isRecoveringHP = false;
				// exit bed
				currMovePattern = EXIT_BED;
			}
		}

		hpValue = (int)hpValueFloat; 

		if(hpValue <= 30)
		{
			if(currMovePattern != MOVE_TO_BED && currMovePattern != SLEEP_IN_BED)
			{
				currMovePattern = MOVE_TO_BED;
			}
			
			isTired = true;
		}
		else
		{
			isTired = false;
		}

	}
}
