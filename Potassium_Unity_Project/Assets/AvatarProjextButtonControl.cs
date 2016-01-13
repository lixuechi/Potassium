using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class AvatarProjextButtonControl : MonoBehaviour {

	void Awake(){
		List<string> btnNames = new List<string> ();
		btnNames.Add ("AvataxButton");
		
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

	void Start () {
	
	}

	void Update () {
	
	}

	void OnClick(GameObject sender)
	{
		switch (sender.name) {
			case "AvataxButton":
				Debug.Log ("Avatax button pushed");
				break;
		}
	}
}
