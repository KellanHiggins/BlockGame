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
		// Settings to figure out which way it is going

		int brickArrayWidth = brickArray.GetUpperBound(0) + 1;
		int brickArrayHeight = brickArray.GetUpperBound(1) + 1;
		int newX;
		int newY;
		int xModifier = 0;
		int yModifier = 0;
		int startX = 0;
		int startY = 0;
		bool movingUpAndDown = false;



//		switch(moveDir)
//		{
//		case MoveDirection.Up:
//			startX = 0;
//			startY = brickArrayHeight - 1;
//			xModifier = 1;
//			yModifier = -1;
//			movingUpAndDown = true;
//			break;
//		case MoveDirection.Down:
//			startX = 0;
//			startY = 0;
//			xModifier = 1;
//			yModifier = 1;
//			movingUpAndDown = true;
//			break;
//		case MoveDirection.Right:
//			startX = brickArrayWidth - 1;
//			startY = 0;
//			xModifier = -1;
//			yModifier = 1;
//			movingUpAndDown = false;
//			break;
//		case MoveDirection.Left:
//			startX = 0;
//			startY = 0;
//			xModifier = 1;
//			yModifier = 1;
//			movingUpAndDown = false;
//			break;
//		default:
//			break;
//		}

		newX = startX;
		newY = startY;

		if(moveDir == MoveDirection.Up)
		{
			// This should all be done by column

			newY = brickArrayHeight - 1;
			newX = 0;
			// Set up here which sides will be affected
			for(int x = 0; x < brickArrayWidth; x++)
			{
				for(int y = brickArrayHeight - 1; y >= 0; y--)
				{
					if(brickArray[x,y] == null || brickArray[x, y] == gameModel.CurrentActiveBrick)
					{
						
					}
					else if(brickArray[x,y] != null)
					{
						BrickComponent brickComponet = brickArray[x, y].GetComponent<BrickComponent>();
						if(brickComponet.Side == Sides.Top || brickComponet.Side == Sides.Bottom)
						{
							// WE NEED TO STOP THIS COLUMN FROM MOVING HERE NOW.
						}
						else if(brickComponet.Side == Sides.Left || brickComponet.Side == Sides.Right)
						{
							gameModel.MoveBrick(brickArray[x,y], moveDir, false);
//							brickArray[x,y].GetComponent<BrickComponent>().Location = new Vector2((float)newX, (float)newY);
//							brickArray[newX, newY] = brickArray[x,y].gameObject;
//							brickArray[x,y] = null;
//							Debug.Log(brickArray[x, y]);
//							Debug.Log(brickArray[newX, newY].gameObject.ToString());
							Debug.Log("New X is: " + newX + ", New Y is: " + newY);
						}

						newY -= 1;
					}
				}
				newY = brickArrayHeight - 1;
				newX += 1;
			}
		}
		else if(moveDir == MoveDirection.Down)
		{
			newY = 0;
			newX = 0;
			// Set up here which sides will be affected
			for(int x = 0; x < brickArrayWidth; x++)
			{
				for(int y = 0; y < brickArrayHeight; y++)
				{
					if(brickArray[x,y] == null || brickArray[x, y] == gameModel.CurrentActiveBrick)
					{
						
					}
					else if(brickArray[x,y] != null)
					{
						BrickComponent brickComponet = brickArray[x, y].GetComponent<BrickComponent>();
						if(brickComponet.Side == Sides.Top || brickComponet.Side == Sides.Bottom)
						{
							
						}
						else if(brickComponet.Side == Sides.Left || brickComponet.Side == Sides.Right)
						{
							gameModel.MoveBrick(brickArray[x,y], moveDir, false);
//							brickArray[x,y].GetComponent<BrickComponent>().Location = new Vector2((float)newX, (float)newY);
//							brickArray[newX, newY] = brickArray[x,y].gameObject;
//							brickArray[x,y] = null;
							Debug.Log("New X is: " + newX + ", New Y is: " + newY);
						}
						
						newY += 1;
					}
				}
				newY = 0;
				newX += 1;
			}
		}
		else if(moveDir == MoveDirection.Left)
		{
			newX = 0;
			newY = brickArrayHeight - 1;
			// Set up here which sides will be affected
			for(int y = brickArrayHeight - 1; y >= 0; y--)
			{
				for(int x = 0; x < brickArrayWidth; x++)
				{
					if(brickArray[x,y] == null || brickArray[x, y] == gameModel.CurrentActiveBrick)
					{
						
					}
					else if(brickArray[x,y] != null)
					{
						BrickComponent brickComponet = brickArray[x, y].GetComponent<BrickComponent>();
						if(brickComponet.Side == Sides.Left || brickComponet.Side == Sides.Right)
						{
							
						}
						else if(brickComponet.Side == Sides.Top || brickComponet.Side == Sides.Bottom)
						{
							gameModel.MoveBrick(brickArray[x,y], moveDir, false);
//							brickArray[x,y].GetComponent<BrickComponent>().Location = new Vector2((float)newX, (float)newY);
//							brickArray[newX, newY] = brickArray[x,y].gameObject;
//							brickArray[x,y] = null;
							Debug.Log("New X is: " + newX + ", New Y is: " + newY);
						}
						
						newX += 1;
					}
				}
				newX = 0;
				newY -= 1;
			}
		}
		else if(moveDir == MoveDirection.Right)
		{
			newX = brickArrayWidth - 1;
			newY = brickArrayHeight - 1;
			// Set up here which sides will be affected
			for(int y = brickArrayHeight - 1; y >= 0; y--)
			{
				for(int x = brickArrayWidth - 1; x >= 0; x--)
				{
					if(brickArray[x,y] == null || brickArray[x, y] == gameModel.CurrentActiveBrick)
					{
						
					}
					else if(brickArray[x,y] != null)
					{
						BrickComponent brickComponet = brickArray[x, y].GetComponent<BrickComponent>();
						if(brickComponet.Side == Sides.Left || brickComponet.Side == Sides.Right)
						{
							
						}
						else if(brickComponet.Side == Sides.Top || brickComponet.Side == Sides.Bottom)
					{
							gameModel.MoveBrick(brickArray[x,y], moveDir, false);
							Debug.Log("New X is: " + newX + ", New Y is: " + newY);
						}
						
						newX -= 1;
					}
				}
				newX = brickArrayWidth - 1;
				newY -= 1;
			}
		}
		moveProcessor.UpdateBrickArray();
	}
}
