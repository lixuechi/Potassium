using UnityEngine;
using System.Collections;

public class FeedFoodToPotassium : MonoBehaviour {

	void Start () {
	
	}

	void Update () {

		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			Debug.Log("Cast a piece of food");

		}
	
	}
}
