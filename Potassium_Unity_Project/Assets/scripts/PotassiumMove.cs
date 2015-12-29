using UnityEngine;
using System.Collections;

public class PotassiumMove : GlobalPotassium {

	public Transform bedTransform;

	private float lastTimeCheckpoint = 0;
	private Vector3 currentPosition = new Vector3();


	int NUM_OF_MOVE_OPTIONS = 0;

	private int randomMovePattern = 0;
	private int currMoveDirection = 0;
	

	private Vector3 horizontalMoveUnit = new Vector3(0.01f, 0, 0);
	private Vector3 verticalMoveUnit = new Vector3(0, 0.01f, 0);


	private Vector3 orangePos = new Vector3();

	void Start () {
		NUM_OF_MOVE_OPTIONS = 5;
	}

	void Update () {

		// make a decision for the moving direction
		if ( (Time.realtimeSinceStartup - lastTimeCheckpoint >= 10 / time_speed)
		   && !(currMovePattern == SLEEP_IN_BED) 
		   && !(currMovePattern == MOVE_TO_BED)
		   && !isTired) 
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
				timeSinceStartMovingInSquare = 0; // init time since start moving in a square
				currMoveDirection = STAY_STATIC;
				currMovePattern = MOVE_IN_SQUARE;
				break;
			}

			lastTimeCheckpoint = Time.realtimeSinceStartup;

		}

		// get the current position of Potassium
		currentPosition = transform.position;

		switch(currMovePattern)
		{
		case MOVE_UP: currentPosition = moveVertically(currentPosition, true, time_speed); 
			break;
		case MOVE_DOWN: currentPosition = moveVertically(currentPosition, false, time_speed);
			break;
		case MOVE_LEFT: currentPosition = moveHorizontally(currentPosition, true, time_speed);
			break;
		case MOVE_RIGHT: currentPosition = moveHorizontally(currentPosition, false, time_speed);
			break;
		case MOVE_IN_CIRCLE: moveInACircle();
			break;
		case MOVE_IN_SQUARE: currentPosition = moveInASquare(currentPosition);
			break;
		case MOVE_TO_ORANGE: currentPosition = moveToOrange(currentPosition);
			break;
		case MOVE_TO_BED: currentPosition = moveToBed(currentPosition);
			break;
		case SLEEP_IN_BED: currentPosition = sleepInBed(currentPosition);
			break;
		case EXIT_BED: currentPosition = exitBed(currentPosition);
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


		// Going to bed if tired or lazy
		if(isTired)
		{
			currMovePattern = MOVE_TO_BED;
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
	Vector3 moveInASquare(Vector3 pos)
	{

		Debug.Log ("func moveInASquare called");
		Debug.Log ("timeSinceStartMovingInSquare == " + timeSinceStartMovingInSquare);
		if (timeSinceStartMovingInSquare % 8 <= 2) 
		{

			pos = moveHorizontally(pos, currMoveDirection == MOVE_LEFT, time_speed);
			currMoveDirection = (currMoveDirection == MOVE_LEFT) ? MOVE_LEFT : MOVE_RIGHT;
			Debug.Log("move in a square: left");
		} 
		else if (timeSinceStartMovingInSquare % 8 <= 4) 
		{
			pos = moveVertically(pos, currMoveDirection == MOVE_UP, time_speed);
			currMoveDirection = (currMoveDirection == MOVE_DOWN) ? MOVE_DOWN : MOVE_UP;
			Debug.Log("move in a square: down");
		} 
		else if (timeSinceStartMovingInSquare % 8 <= 6) 
		{
			pos = moveHorizontally(pos, currMoveDirection == MOVE_LEFT, time_speed);
			currMoveDirection = (currMoveDirection == MOVE_RIGHT) ? MOVE_RIGHT : MOVE_LEFT;
			Debug.Log("move in a square: right");
		} 
		else if (timeSinceStartMovingInSquare % 8 <= 8) 
		{
			pos = moveVertically(pos, currMoveDirection == MOVE_UP, time_speed);
			currMoveDirection = (currMoveDirection == MOVE_UP) ? MOVE_UP : MOVE_DOWN;
			Debug.Log("move in a square: up");
		} 
		else 
		{

		}
		timeSinceStartMovingInSquare += Time.deltaTime;

		return pos;
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

	Vector3 moveToBed(Vector3 currPos)
	{
		Vector3 bedPos = bedTransform.position;
		if(bedPos.x - currPos.x > 0)
		{
			currPos += horizontalMoveUnit * time_speed;
		}
		else if(bedPos.x - currPos.x < 0)
		{
			currPos -= horizontalMoveUnit * time_speed;
		}
		
		if(bedPos.y - currPos.y > 0)
		{
			currPos += verticalMoveUnit * time_speed;
		}
		else if(bedPos.y - currPos.y < 0)
		{
			currPos -= verticalMoveUnit * time_speed;
		}

		if(bedPos.x - currPos.x <= 0.0001f && bedPos.y - currPos.y <= 0.0001f)
		{
			Debug.Log("Move pattern changes from MOVE_TO_BED to SLEEP_IN_BED");
			currMovePattern = SLEEP_IN_BED;
		}
		

		return currPos;		
	}

	Vector3 sleepInBed(Vector3 currPos)
	{
		if(hpValue <= 99)
		{
		}
		else
		{
			currMovePattern = EXIT_BED;
		}
		
		return currPos;
	}

	Vector3 exitBed(Vector3 currPos)
	{
		if(currPos.x < 0)
		{
			currPos += horizontalMoveUnit;
		}
		if(currPos.y < 0)
		{
			currPos += verticalMoveUnit;
		}
		else if(currPos.y > 0)
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
