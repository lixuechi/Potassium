using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {

	public Transform Potassium;

	void Start () {
	
	}
	
	void Update () {
		if(Input.GetMouseButton(0))
		{
			Debug.Log("Mouse left button down");
			Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(Potassium.position);
			Vector3 offset = Potassium.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z));

			Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z);
			Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
			Potassium.position = CurPosition;
		}
	}
	/*
	IEnumerator OnMouseDown()
	{
		Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(Potassium.position);
		Vector3 offset = Potassium.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z));

		Debug.Log("Mouse down");

		while(Input.GetMouseButton(0))
		{
			Debug.Log("Mouse left button down");
			Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z);
			Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
			Potassium.position = CurPosition;

			yield return new WaitForFixedUpdate();
		}
	}
	*/
}
