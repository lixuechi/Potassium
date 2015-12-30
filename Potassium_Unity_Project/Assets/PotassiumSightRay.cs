using UnityEngine;
using System.Collections;

public class PotassiumSightRay : MonoBehaviour {

	public Transform sightRayPrefab;

	void Start () {

		Transform s = Instantiate(sightRayPrefab, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
	
	}
	
	void Update () {
	
	}
}
