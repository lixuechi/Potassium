using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonMainControl : GlobalPotassium {

	public Transform OrangeFeed;
	public Text hackText;
	

	void Start () {
		List<string> btnNames = new List<string> ();
		btnNames.Add ("Feed");
		btnNames.Add("Hack");

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
		}
	}

	void Update () {
	
	}
}
