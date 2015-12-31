using UnityEngine;
using System.Collections;

public class OwlControl : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {

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
	
	}
}
