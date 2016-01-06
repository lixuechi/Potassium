using UnityEngine;
using System.Collections;

public class OriginPotassiumMoveForPixium : MonoBehaviour {

	static bool isRegenerateOranges = false;
	public Transform OrangePrefab;

	void Start () {
	
	}

	void Update () {

		if (Input.GetKey (KeyCode.UpArrow)
			|| Input.GetKey (KeyCode.DownArrow)
			|| Input.GetKey (KeyCode.LeftArrow)
			|| Input.GetKey (KeyCode.RightArrow)) 
		{
			if (Input.GetKey (KeyCode.UpArrow)) 
			{
				this.transform.position += new Vector3(0, 0.1f, 0);
			}
			else if (Input.GetKey (KeyCode.DownArrow)) 
			{
				this.transform.position += new Vector3(0, -0.1f, 0);
			}
			else if (Input.GetKey (KeyCode.LeftArrow)) 
			{
				this.transform.position += new Vector3(-0.1f, 0, 0);
			}
			else if (Input.GetKey (KeyCode.RightArrow)) 
			{
				this.transform.position += new Vector3(0.1f, 0, 0);
			}

			// if Potassium moves, regenerate all the oranges
			isRegenerateOranges = true;
		}

		if (isRegenerateOranges) 
		{
			regenerateOranges();
			isRegenerateOranges = false;
		}
	
	}

	void regenerateOranges()
	{
	}
}
