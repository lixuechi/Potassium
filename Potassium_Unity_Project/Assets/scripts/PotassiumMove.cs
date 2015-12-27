using UnityEngine;
using System.Collections;

public class PotassiumMove : GlobalPotassium {

	private float lastTimeCheckpoint = 0;
	private Vector3 currentPosition = new Vector3();

	const int MOVE_UP = 0;
	const int MOVE_DOWN = 1;
	const int MOVE_LEFT = 2;
	const int MOVE_RIGHT = 3;
	const int MOVE_IN_CIRCLE = 4;
	const int MOVE_IN_SQUARE = 5;
	const int STAY_STATIC = 6;
	const int MOVE_TO_ORANGE = 7;
	int NUM_OF_MOVE_OPTIONS = 0;

	private int randomMovePattern = 0;
	private int currMoveDirection = 0;
	private int currMovePattern = 0;

	private Vector3 horizontalMoveUnit = new Vector3(0.01f, 0, 0);
	private Vector3 verticalMoveUnit = new Vector3(0, 0.01f, 0);


	private Vector3 orangePos = new Vector3();

	void Start () {
		NUM_OF_MOVE_OPTIONS = 6;
	}

	void Update () {

		// make a decision for the moving direction
		if (Time.realtimeSinceStartup - lastTimeCheckpoint >= 5) 
		{
			Debug.Log("Last time checkpoint updated");

			// determine where to go in each a few seconds
			randomMovePattern = Random.Range(MOVE_UP, NUM_OF_MOVE_OPTIONS + 1);
			switch(randomMovePattern)
			{
			case MOVE_UP: Debug.Log("Move up");
						  currMoveDirection = MOVE_UP;
				currMovePattern = MOVE_UP;
						  break;
			case MOVE_DOWN: Debug.Log("Move down");
						    currMoveDirection = MOVE_DOWN;
				currMovePattern = MOVE_DOWN;
							break;
			case MOVE_LEFT: Debug.Log("Move left");
							currMoveDirection = MOVE_LEFT;
				currMovePattern = MOVE_LEFT;
							break;
			case MOVE_RIGHT: Debug.Log("Move right");
							 currMoveDirection = MOVE_RIGHT;
				currMovePattern = MOVE_RIGHT;
							 break;
			case MOVE_IN_CIRCLE: Debug.Log("Move in a circle");
				currMoveDirection = STAY_STATIC;
				currMovePattern = MOVE_IN_CIRCLE;
				break;
			case MOVE_IN_SQUARE: Debug.Log("Move in a square");
				currMoveDirection = STAY_STATIC;
				currMovePattern = MOVE_IN_SQUARE;
				break;
			case MOVE_TO_ORANGE: Debug.Log("Move to the orange(s)");
				currMovePattern = MOVE_TO_ORANGE;
				break;
			default: Debug.Log("Default move up");
					 currMoveDirection = MOVE_UP;
				currMovePattern = MOVE_UP;
					 break;
			}

			lastTimeCheckpoint = Time.realtimeSinceStartup;

		}

		// get the current position of Potassium
		currentPosition = transform.position;

		switch(currMovePattern)
		{
		case MOVE_UP: currentPosition += verticalMoveUnit;
			break;
		case MOVE_DOWN: currentPosition -= verticalMoveUnit;
			break;
		case MOVE_LEFT: currentPosition -= horizontalMoveUnit;
			break;
		case MOVE_RIGHT: currentPosition += horizontalMoveUnit;
			break;
		case MOVE_IN_CIRCLE: moveInACircle();
			break;
		case MOVE_IN_SQUARE: currentPosition = moveInASquare();
			break;
		case MOVE_TO_ORANGE: currentPosition = moveToOrange(currentPosition);
			break;
		}


		// update boundaries
		if (currentPosition.x <= -7 || currentPosition.x >= 7) 
		{
			Debug.Log("Move direction changed due to the boundary");
			currMoveDirection = (currMoveDirection == MOVE_LEFT) ? MOVE_RIGHT : MOVE_LEFT;
			currMovePattern = (currMovePattern == MOVE_LEFT) ? MOVE_RIGHT : MOVE_LEFT;
		}
		if (currentPosition.y <= -4 || currentPosition.y >= 4) 
		{
			Debug.Log("Move direction changed due to the boundary");
			currMoveDirection = (currMoveDirection == MOVE_UP) ? MOVE_DOWN : MOVE_UP;
			currMovePattern = (currMovePattern == MOVE_UP) ? MOVE_DOWN : MOVE_UP;
		}

		
		// Going to the orange(s) if there's any
		if(isOrangePresent)
		{
			if(orangeTransform != null)
			{
				orangePos = orangeTransform.position;

				currMovePattern = MOVE_TO_ORANGE;
			}
		}


		// copy the changes made for current position
		transform.position = currentPosition;
	}

	Vector3 moveHorizontally(Vector3 currPos, bool isToLeft, int speed)
	{
		currPos += isToLeft ? (- horizontalMoveUnit * speed) : (horizontalMoveUnit * speed);
		return currPos;
	}

	Vector3 moveVertically(Vector3 currPos, bool isToUp, int speed)
	{
		currPos += isToUp ? (- verticalMoveUnit * speed) : (verticalMoveUnit * speed);
		return currPos;
	}

	// Counter-clockwise: left -> down -> right -> up -> left
	static float timeSinceStartMovingInSquare = 0;
	static Vector3 currPosWhenMovingInSquare = new Vector3();
	Vector3 moveInASquare()
	{

		Debug.Log ("func moveInASquare called");
		Debug.Log ("timeSinceStartMovingInSquare == " + timeSinceStartMovingInSquare);
		if (timeSinceStartMovingInSquare <= 2) 
		{
			currPosWhenMovingInSquare = moveHorizontally(currPosWhenMovingInSquare, true, 1);
			currMoveDirection = MOVE_LEFT;
			Debug.Log("move in a square: left");
		} 
		else if (timeSinceStartMovingInSquare <= 4) 
		{
			currPosWhenMovingInSquare = moveVertically(currPosWhenMovingInSquare, false, 1);
			currMoveDirection = MOVE_DOWN;
			Debug.Log("move in a square: down");
		} 
		else if (timeSinceStartMovingInSquare <= 6) 
		{
			currPosWhenMovingInSquare = moveHorizontally(currPosWhenMovingInSquare, false, 1);
			currMoveDirection = MOVE_RIGHT;
			Debug.Log("move in a square: right");
		} 
		else if (timeSinceStartMovingInSquare <= 8) 
		{
			currPosWhenMovingInSquare = moveVertically(currPosWhenMovingInSquare, true, 1);
			currMoveDirection = MOVE_UP;
			Debug.Log("move in a square: up");
		} 
		else 
		{

		}
		timeSinceStartMovingInSquare += Time.deltaTime;

		return currPosWhenMovingInSquare;
	}

	Vector3 moveToOrange(Vector3 currPos)
	{
		if(orangePos.x - currPos.x > 0)
		{
			currPos += horizontalMoveUnit;
		}
		else if(orangePos.x - currPos.x < 0)
		{
			currPos -= horizontalMoveUnit;
		}
		
		if(orangePos.y - currPos.y > 0)
		{
			currPos += verticalMoveUnit;
		}
		else if(orangePos.y - currPos.y < 0)
		{
			currPos -= verticalMoveUnit;
		}
		

		return currPos;
	}

	const int moveCircleRadius = 1;
	void moveInACircle()
	{
		Vector3 originOfCircle = transform.position - new Vector3 (0, moveCircleRadius, 0);
	}

}
