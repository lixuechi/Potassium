using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OwlControl : MonoBehaviour {

	public Transform harmPrefab;
	Transform harm;
	Text harmText;
	static bool isShowHarmText = false;

	void Start () 
	{
		if(harmPrefab != null)
		{
			harmText = harmPrefab.gameObject.GetComponent<Text>();
		}	
	}
	
	void Update () 
	{

		if(Input.GetKey(KeyCode.UpArrow))
		{
			Debug.Log("move the owl upward");
			this.transform.position += new Vector3(0, 0.1f, 0);
		}	
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			this.transform.position += new Vector3(0, -0.1f, 0);
		}
		else if(Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.position += new Vector3(-0.1f, 0, 0);
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.position += new Vector3(0.1f, 0, 0);
		}

		if(isShowHarmText)
		{
			if(harm == null)
			{
				harm = Instantiate(harmPrefab, this.transform.position, Quaternion.identity) as Transform;
			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			isShowHarmText = true;
		}
	}
}
