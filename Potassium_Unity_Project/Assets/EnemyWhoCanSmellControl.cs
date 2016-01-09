using UnityEngine;
using System.Collections;

public class EnemyWhoCanSmellControl : MonoBehaviour {

	Vector3 moveXUnit = new Vector3(0, 0.1f, 0);
	Vector3 moveYUnit = new Vector3(0.1f, 0, 0);

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Orange") 
		{
			Vector3 odorPos = coll.gameObject.transform.position;
			Vector3 enemyPos = this.transform.position;

			enemyPos += (enemyPos.x - odorPos.y > 0) ? (moveXUnit) : (-moveXUnit);
			enemyPos += (enemyPos.y - odorPos.y < 0) ? (moveYUnit) : (-moveYUnit);

			this.transform.position = enemyPos;
		}
	}
}
