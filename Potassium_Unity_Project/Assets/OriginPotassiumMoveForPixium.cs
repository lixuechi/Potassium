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

	void deleteAllPresentOranges()
	{
		try
		{
			GameObject[] bunchOfOrangesToDelete = GameObject.FindGameObjectsWithTag("Orange");
			for(int x = 0; x < bunchOfOrangesToDelete.Length; x++)
			{
				Destroy (bunchOfOrangesToDelete[x]);
			}

		}
		catch(UnityException e)
		{
			return;
		}
	}

	void regenerateOranges()
	{
		deleteAllPresentOranges ();
		for (int i = 0; i < 20; i++) 
		{
			for(int j = 0; j < 20; j++)
			{
				Transform _666 = Instantiate (OrangePrefab, new Vector3(-5+i*0.5f,-5+j*0.5f,0), Quaternion.identity) as Transform;
				_666.parent = this.transform;
			}
		}
	}
}
