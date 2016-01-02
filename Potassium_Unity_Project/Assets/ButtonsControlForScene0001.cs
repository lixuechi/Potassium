using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonsControlForScene0001 : MonoBehaviour {

	void Start () 
	{
		List<string> btnNames = new List<string> ();
		btnNames.Add ("GoToPlayground");

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
	
	void Update () 
	{
	
	}

	void OnClick(GameObject sender)
	{
		switch(sender.name)
		{
			case "GoToPlayground":
			Debug.Log("GoToPlayground button pushed");
			Application.LoadLevel("0000");
			break;
		}
	}
}
