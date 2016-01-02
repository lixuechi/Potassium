using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonsControlForScene0001 : MonoBehaviour {

	public GameObject PotassiumIconButton;
	public GameObject OpenResultButton;
	public GameObject Os;
	public GameObject[] Obasket; 

	void Awake()
	{
		List<string> btnNames = new List<string> ();
		btnNames.Add ("GoToPlayground");
		btnNames.Add("Fortune");
		btnNames.Add("OpenResult");
		
		foreach (string btnName in btnNames) 
		{
			GameObject btnObj = GameObject.Find (btnName);
			Button btn = btnObj.GetComponent<Button>();
			btn.onClick.AddListener(delegate()
			                        {
				this.OnClick(btnObj);
			});
		}

		OpenResultButton.SetActive (false);
		Os.SetActive (false);
	}

	void Start () 
	{

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
			case "Fortune":
			Debug.Log("Potassium icon button pushed");
			OpenResultButton.SetActive(true);
			PotassiumIconButton.SetActive(false);
		    break;
		case "OpenResult":
			Debug.Log("Open Result button pushed");
			generateFortuneTellingResult();
			Os.SetActive(true);
			OpenResultButton.SetActive(false);
			PotassiumIconButton.SetActive(true);
			break;
		}
	}

	const int NUM_OF_FORTUNE_TELLING_ORANGES = 7;
	void generateFortuneTellingResult()
	{
		int rand = Random.Range (0, NUM_OF_FORTUNE_TELLING_ORANGES + 1);

		for (int i = 0; i < rand; i++) 
		{
			Obasket[i].SetActive(true);
		}
		for (int i = rand; i < NUM_OF_FORTUNE_TELLING_ORANGES; i++) 
		{
			Obasket[i].SetActive(false);
		}
	}
}
