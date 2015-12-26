using UnityEngine;
using System.Collections;

public class PotassiumMove : MonoBehaviour {

	private float lastTimeCheckpoint = 0;
	private Vector3 currentPosition = new Vector3();

	const int MOVE_UP = 0;
	const int MOVE_DOWN = 1;
	const int MOVE_LEFT = 2;
	const int MOVE_RIGHT = 3;

	private int randomMoveDirection = 0;
	private int currMoveDirection = 0;

	private Vector3 horizontalMoveUnit = new Vector3(0.01f, 0, 0);
	private Vector3 verticalMoveUnit = new Vector3(0, 0.01f, 0);

	void Start () {
	
	}

	void Update () {

		// make a decision for the moving direction
		if (Time.realtimeSinceStartup - lastTimeCheckpoint >= 5) 
		{
			Debug.Log("Last time checkpoint updated");

			// determine where to go in each a few seconds
			randomMoveDirection = Random.Range(MOVE_UP, MOVE_RIGHT + 1);
			switch(randomMoveDirection)
			{
			case MOVE_UP: Debug.Log("Move up");
						  currMoveDirection = MOVE_UP;
						  break;
			case MOVE_DOWN: Debug.Log("Move down");
						    currMoveDirection = MOVE_DOWN;
							break;
			case MOVE_LEFT: Debug.Log("Move left");
							currMoveDirection = MOVE_LEFT;
							break;
			case MOVE_RIGHT: Debug.Log("Move right");
							 currMoveDirection = MOVE_RIGHT;
							 break;
			default: Debug.Log("Default move up");
					 currMoveDirection = MOVE_UP;
					 break;
			}

			lastTimeCheckpoint = Time.realtimeSinceStartup;

		}

		// get the current position of Potassium
		currentPosition = transform.position;

		switch(currMoveDirection)
		{
		case MOVE_UP: currentPosition += verticalMoveUnit;
			break;
		case MOVE_DOWN: currentPosition -= verticalMoveUnit;
			break;
		case MOVE_LEFT: currentPosition -= horizontalMoveUnit;
			break;
		case MOVE_RIGHT: currentPosition += horizontalMoveUnit;
			break;
		}


		// update boundaries
		if (currentPosition.x <= -7 || currentPosition.x >= 7) 
		{
			Debug.Log("Move direction changed due to the boundary");
			currMoveDirection = (currMoveDirection == MOVE_LEFT) ? MOVE_RIGHT : MOVE_LEFT;
		}
		if (currentPosition.y <= -4 || currentPosition.y >= 4) 
		{
			Debug.Log("Move direction changed due to the boundary");
			currMoveDirection = (currMoveDirection == MOVE_UP) ? MOVE_DOWN : MOVE_UP;
		}

		
		// copy the changes made for current position
		transform.position = currentPosition;
	}
}
