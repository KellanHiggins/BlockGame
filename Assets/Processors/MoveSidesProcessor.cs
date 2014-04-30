using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MoveSidesProcessor : MonoBehaviour 
{
	GameModel gameModel;
	MoveProcessor moveProcessor;

	void Start()
	{
		moveProcessor = gameObject.GetComponent<MoveProcessor>();
		gameModel = GameObject.FindObjectOfType<GameModel>();
	}

	public bool MoveAllofOneSide(Sides side)
	{
		return true;
	}

	public void MoveUp(GameObject[,] brickArray)
	{
		// This takes the entire BrickArray and goes column by column moving every block that is in the side up to the top of its column.

		// First 

		int brickArrayWidth = brickArray.GetUpperBound(0) + 1;
		int brickArrayHeight = brickArray.GetUpperBound(1) + 1;

		int newX = 0;
		int newY = brickArrayHeight - 1;

		for(int x = 0; x < brickArrayWidth; x++)
		{

			for(int y = brickArrayHeight - 1; y >= 0; y--)
			{
				if(brickArray[x,y] == null)
				{

				}
				// Need to add in a check to see which side the brick is on
				else if(brickArray[x,y] != null)
				{
					Debug.Log(brickArray[x,y].ToString());
					brickArray[x,y].GetComponent<BrickComponent>().Location = new Vector2((float)newX, (float)newY);
					newY--;
				}

			}
			newY = brickArrayHeight - 1;
			newX++;
		}
		moveProcessor.UpdateBrickArray();
	}

	// Write a general move command that uses only the directions

	public void Move(GameObject[,] brickArray, MoveDirection moveDir)
	{
		int brickArrayWidth = brickArray.GetUpperBound(0) + 1;
		int brickArrayHeight = brickArray.GetUpperBound(1) + 1;
//		int newX = 0; // needs to change depending
//		int newY = brickArrayHeight - 1; // needs to change depending
//		
//		for(int x = 0; x < brickArrayWidth; x++) // the lenght needs to change depending
//		{
//			for(int y = brickArrayHeight - 1; y >= 0; y--)
//			{
//				if(brickArray[x,y] == null)
//				{
//					
//				}
//				// Need to add in a check to see which side the brick is on
//				else if(brickArray[x,y] != null)
//				{
//					brickArray[x,y].GetComponent<BrickComponent>().Location = new Vector2((float)newX, (float)newY);
//					newY--; // needs to change depending
//				}
//				
//			}
//			newY = brickArrayHeight - 1; // needs to be reset depending
//			newX++; // needs to change depending
//		}
//		moveProcessor.UpdateBrickArray();

		// UP
		// Requires to count down from the top to the bottom. x starts at 0 and increases to 9 y starts at 15 counts to 0. 
		// 

		// DOWN
		// Requires to count up from the bottom. x starts at 0 and increases to 9 and y starts at 0 and increased to 9

		// Right
		// Requires to count from the Left to the Right by row instead of column. increase from 0 to 9, y decreases from 15 to 0 (gonna count from top to bottom for no good reason)

		// Left requiest to count from the Right to the left by row. Decrease from 9 to 0, y will decrease from 15 to aught

		// So we need a few variables
		// We will 


		// So in this case we are going to standardize the count, just modify the rotation basically. This is probably going to be very confusing
		// Actually maybe not. It just depends on where we start counting from, which corner.

//		int startingX = 0; // or 9
//		int startingY = startingY;

		// set newX depending on which way we are going
		// Also give direction
		// 

		// Up is STARTATTOP, go down
		// DOWN is STARTATBOTTOM, go up
		// UP AND DOWN always have the same X movement, left to right

		// This is for UP

		int newX;
		int newY;
		int xModifier = 0;
		int yModifier = 0;
		int startX = 0;
		int startY = 0;
		bool movingUpAndDown = false;

		switch(moveDir)
		{
		case MoveDirection.Up:
			startX = 0;
			startY = brickArrayHeight - 1;
			xModifier = 1;
			yModifier = -1;
			movingUpAndDown = true;
			break;
		case MoveDirection.Down:
			startX = 0;
			startY = 0;
			xModifier = 1;
			yModifier = 1;
			movingUpAndDown = true;
			break;
		case MoveDirection.Right:
			startX = brickArrayWidth - 1;
			startY = 0;
			xModifier = -1;
			yModifier = 1;
			movingUpAndDown = false;
			break;
		case MoveDirection.Left:
			startX = 0;
			startY = 0;
			xModifier = 1;
			yModifier = 1;
			movingUpAndDown = false;
			break;
		default:
			break;
		}

		newX = startX;
		newY = startY;

		// This for up and down movement
		if(movingUpAndDown)
		{
			for(int x = 0; x < brickArrayWidth; x++)
			{
				for(int y = 0; y < brickArrayHeight; y++)
				{
					if(brickArray[x,y] == null || brickArray[x, y] == gameModel.CurrentActiveBrick)
					{
						
					}
					// Need to add in a check to see which side the brick is on
					else if(brickArray[x,y] != null)
					{
						brickArray[x,y].GetComponent<BrickComponent>().Location = new Vector2((float)newX, (float)newY);
						newY += yModifier;
					}
				}
				newY = startY;
				newX += xModifier;
			}
		}
		else if(!movingUpAndDown)
		{
			// This is for left and right movement

			// Testing out a left movement
			for(int y = 0; y < brickArrayHeight; y++)
			{
				for(int x = 0; x < brickArrayWidth; x++)
				{
					if(brickArray[x,y] == null || brickArray[x, y] == gameModel.CurrentActiveBrick)
					{
						
					}
					// Need to add in a check to see which side the brick is on
					else if(brickArray[x,y] != null)
					{
						brickArray[x,y].GetComponent<BrickComponent>().Location = new Vector2((float)newX, (float)newY);
						newX += xModifier;
					}
				}
				newX = startX;
				newY += yModifier;
			}
		}
		moveProcessor.UpdateBrickArray();
	}










	public List<BrickComponent> FindAllSideObjects(Sides side)
	{
		List<BrickComponent> sideObjects = new List<BrickComponent>();
		BrickComponent[] brickComponents = GameObject.FindObjectsOfType<BrickComponent>();


		foreach(var brickComponent in brickComponents)
		{
			if(brickComponent.Side == side)
			{
				sideObjects.Add(brickComponent);
			}
		}

		Debug.Log(sideObjects.Count);

		return sideObjects;

//		for(int i = 0; i < releventGameObjects.Count; i++)
//		{
//			if(releventGameObjects[i] > releventGameObjects[e
//
//		}
	}

	public BrickComponent[,] FindAllSideObjects(GameObject[,] brickArray, Sides side)
	{
		BrickComponent[,] newBrickComponent = new BrickComponent[brickArray.GetUpperBound(0) + 1, brickArray.GetUpperBound(1) + 1];
		//Debug.Log("X width: " + brickArray.GetUpperBound(0) + "Y width: " + brickArray.GetUpperBound(1));
		for(int x = 0; x < brickArray.GetUpperBound(0); x++)
		{
			for(int y = 0; y < brickArray.GetUpperBound(1); y++)
			{
				if(brickArray[x,y] != null)
				{
					BrickComponent brickComponent = brickArray[x,y].GetComponent<BrickComponent>();
					if(brickComponent != null && brickComponent.Side == side)
					{
						newBrickComponent[x,y] = brickComponent;
					}
				}
			}
		}
		return newBrickComponent;
	}
}
