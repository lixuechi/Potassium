using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedControl : GlobalPotassium {

	Text speedValText;

	void Start () {
		speedValText = GetComponent<Text>();
	}
	
	void Update () {
	
		if(speedValText != null)
		{
			speedValText.text = time_speed + "";
		}

	}
}
