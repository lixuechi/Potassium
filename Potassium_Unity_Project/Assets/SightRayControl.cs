using UnityEngine;
using System.Collections;

public class SightRayControl : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
		//this.transform.localScale += new Vector3(0.1f * Time.deltaTime, 0, 0);

	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag != "Player")
		{
			Debug.Log("Sight ray hits " + coll.gameObject.tag);
			this.transform.localScale = new Vector3(this.transform.localScale.x * 0.95f, 0.3f, 1);
		}
	}
	/*
	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag != "Player")
		{
			Debug.Log("Sight ray keeps hitting " + coll.gameObject.tag);
			this.transform.localScale = new Vector3(this.transform.localScale.x * 0.95f, 0.3f, 1);
		}
	}
	*/
}
