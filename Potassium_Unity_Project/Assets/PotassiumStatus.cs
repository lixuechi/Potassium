using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PotassiumStatus : GlobalPotassium {

	public GameObject hpTextObj;
	Text hpText;

	void Start () {
		hpText = hpTextObj.GetComponent<Text>();
	}
	
	void Update () {
	
		if(!isHackOn)
		{
			hpText.text = "";
		}
		else if(hpText != null)
		{
			hpText.text = "HP: " + hpValue;
			//Debug.Log("HP is " + hpValue);
		}

	}
}
