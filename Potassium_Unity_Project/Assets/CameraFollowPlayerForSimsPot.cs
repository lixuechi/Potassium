using UnityEngine;
using System.Collections;

public class CameraFollowPlayerForSimsPot : MonoBehaviour {

	public Transform PotTR;

	void Start () 
	{
	
	}

	void Update () 
	{
		this.transform.position = new Vector3(PotTR.position.x, PotTR.position.y, this.transform.position.z);
	}
}
