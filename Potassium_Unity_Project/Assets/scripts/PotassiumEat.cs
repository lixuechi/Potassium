using UnityEngine;
using System.Collections;

public class PotassiumEat : GlobalPotassium {

	void Start () {
	
	}
	
	void Update () {
	
		if(isOrangePresent)
		{
			Debug.Log("Start going to the orange");
		}

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Orange")
		{
			Debug.Log("Orange eaten");
		}
	}
}
