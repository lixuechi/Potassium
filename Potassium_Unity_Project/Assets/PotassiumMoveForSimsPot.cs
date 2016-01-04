using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PotassiumMoveForSimsPot : MonoBehaviour {

	public Text reactionText;
	const int ACTION_VOID = 0;
	const int ACTION_SLEEP = 1;
	int currAction = 0;

	void Start () 
	{
	
	}

	void Update () 
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			this.transform.position += new Vector3 (0, 0.1f, 0);
		} 
		else if (Input.GetKey (KeyCode.DownArrow)) 
		{
			this.transform.position -= new Vector3(0, 0.1f, 0);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.position += new Vector3 (0.1f, 0, 0);
		} 
		else if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			this.transform.position -= new Vector3(0.1f, 0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Bed") 
		{
			reactionText.text = "Sleep";
			currAction = ACTION_SLEEP;
		} 
		else if (coll.gameObject.tag == "Toilet") 
		{
			reactionText.text = "Pee/Poop";

		}
		else if (coll.gameObject.tag == "Bathtub") 
		{
			reactionText.text = "Bathe";
			
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		reactionText.text = "";
		currAction = ACTION_VOID;
	}
}
