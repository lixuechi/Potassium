using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonMainControl : GlobalPotassium {

	public Transform OrangeFeed;
	public Transform BlueBallFeed;
	public Transform OwlFeed;
	public Text hackText;
	

	void Start () {
		List<string> btnNames = new List<string> ();
		btnNames.Add ("Feed");
		btnNames.Add("Hack");
		btnNames.Add("Minus");
		btnNames.Add("Plus");
		btnNames.Add("Train(Voice)");
		btnNames.Add("Tickle");
		btnNames.Add("Slash");

		foreach (string btnName in btnNames) 
		{
			GameObject btnObj = GameObject.Find (btnName);
			Button btn = btnObj.GetComponent<Button>();
			btn.onClick.AddListener(delegate()
			{
				this.OnClick(btnObj);
			});
		}
	}

	void OnClick(GameObject sender)
	{
		switch(sender.name)
		{
			case "Feed":
			Debug.Log("Feed button pushed");
			Transform orange = Instantiate(OrangeFeed, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
			isOrangePresent = true;
			break;
			case "Hack":
			Debug.Log("Hack button pushed");
			// show/hide the statistics
			isHackOn = !isHackOn;
			hackText.text = isHackOn ? "Hack On" : "Hack Off";
			break;
			case "Minus":
			Debug.Log("Decrement speed");
			time_speed--;
			break;
			case "Plus":
			Debug.Log("Increment speed");
			time_speed++;
			break;
			case "Train(Voice)":
			Debug.Log("Train Potassium with voice system");
			break;
			case "Tickle":
			Debug.Log("Tickle Potassium with a blue ball or sth else");
			ticklePotassium();
			break;
			case "Slash":
			Debug.Log("Slash: Let the slash begin!");
			OwlAppears();
			break;
		}
	}

	void Update () {
	
	}

	void ticklePotassium()
	{
		BlueBall = Instantiate(BlueBallFeed, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
		isBlueBallPresent = true;
	}

	void OwlAppears()
	{
		Owl = Instantiate(OwlFeed, new Vector3(-2, 0, 0), Quaternion.identity) as Transform;
	}
}
