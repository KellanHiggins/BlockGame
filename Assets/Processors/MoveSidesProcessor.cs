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
//		int xModifier = 0;
//		int yModifier = 0;
		int startX = 0;
		int startY = 0;
//		bool movingUpAndDown = false;

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
						BrickTypeComponent brickTypeComponet = brickArray[x, y].GetComponent<BrickTypeComponent>();
						if(brickTypeComponet.Side == Sides.Top || brickTypeComponet.Side == Sides.Bottom)
						{
						}
						else if(brickTypeComponet.Side == Sides.Left || brickTypeComponet.Side == Sides.Right)
						{
							gameModel.MoveBrick(brickArray[x,y], moveDir, false);
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
						BrickTypeComponent brickTypeComponet = brickArray[x, y].GetComponent<BrickTypeComponent>();
						if(brickTypeComponet.Side == Sides.Top || brickTypeComponet.Side == Sides.Bottom)
						{
							
						}
						else if(brickTypeComponet.Side == Sides.Left || brickTypeComponet.Side == Sides.Right)
						{
							gameModel.MoveBrick(brickArray[x,y], moveDir, false);
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
						BrickTypeComponent brickTypeComponet = brickArray[x, y].GetComponent<BrickTypeComponent>();
						if(brickTypeComponet.Side == Sides.Left || brickTypeComponet.Side == Sides.Right)
						{
							
						}
						else if(brickTypeComponet.Side == Sides.Top || brickTypeComponet.Side == Sides.Bottom)
						{
							gameModel.MoveBrick(brickArray[x,y], moveDir, false);
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
						BrickTypeComponent brickTypeComponet = brickArray[x, y].GetComponent<BrickTypeComponent>();
						if(brickTypeComponet.Side == Sides.Left || brickTypeComponet.Side == Sides.Right)
						{
							
						}
						else if(brickTypeComponet.Side == Sides.Top || brickTypeComponet.Side == Sides.Bottom)
						{
							gameModel.MoveBrick(brickArray[x,y], moveDir, false);

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
