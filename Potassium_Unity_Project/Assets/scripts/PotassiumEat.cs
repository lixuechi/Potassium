using UnityEngine;
using System.Collections;

public class PotassiumEat : GlobalPotassium {

	GameObject orangeClone;

	void Start () {
	
	}
	
	void Update () {
	
		if(isOrangePresent)
		{
			Debug.Log("Start going to the orange");
			orangeClone = GameObject.Find("Orange(Clone)");
			orangeTransform = orangeClone.transform;
		}

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Orange")
		{
			Debug.Log("Orange eaten");
			if(orangeClone != null)
			{
				Destroy(orangeClone);
				isOrangePresent = false;
			}
		}
	}
}
