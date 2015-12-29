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

	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Bed")
		{
			if(hpValue <= 30)
			{
				// recover HP
				Debug.Log("On trigger stay with Bed");
				isRecoveringHP = true;
			}

		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Bed" && isRecoveringHP)
		{
			isRecoveringHP = false;
			Debug.Log("On trigger exit bed");
		}
	}
}
