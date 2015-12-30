using UnityEngine;
using System.Collections;

public class PotassiumSightRay : MonoBehaviour {

	public Transform sightRayPrefab;
	Transform[] sightRays = new Transform[36];

	void Start () {

		for(int i = 0; i < 36; i++)
		{
			Transform s = Instantiate(sightRayPrefab, this.transform.position, Quaternion.identity) as Transform;
			s.Rotate(new Vector3(0, 0, i * 10));

			sightRays[i] = s;
		}
	
	}
	
	void Update () {

		for(int k = 0; k < 36; k++)
		{
			sightRays[k].transform.position = this.transform.position;
		}
	
	}


}
