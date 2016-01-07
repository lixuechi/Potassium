using UnityEngine;
using System.Collections;

public class PixiumCamFollowsPotassium : MonoBehaviour {

	public Transform PsmTR;

	void Start () {
	
	}

	void Update () {

		this.transform.position = new Vector3 (PsmTR.position.x, PsmTR.position.y, -10);
	
	}
}
