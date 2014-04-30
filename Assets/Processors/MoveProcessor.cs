using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveProcessor : MonoBehaviour 
{

	private GameModel gameModel;
	private DirectionChecker directionChecker;

	void Awake () 
	{
		gameModel = FindObjectOfType<GameModel>();
		directionChecker = GameObject.Find("Processors").GetComponent<DirectionChecker>();
	}

	// TODO: Change this to one method to move in any direction
	public bool MoveRight(GameObject brick, bool updateSide)
	{
		if(directionChecker.CheckRight(brick, gameModel.BrickArray) > 0)
		{
			BrickComponent brickComponent = brick.GetComponent<BrickComponent>();
			brickComponent.Location.x = brickComponent.Location.x + directionChecker.CheckRight(brick, gameModel.BrickArray);
			//UpdateActualLocation(brickComponent.gameObject);
			if(updateSide == true)
			{
				brickComponent.Side = Sides.Right;
			}
			// Update the brick array so that everything is aligned.
			UpdateBrickArray();
			return true;
		}
		return false;
	}

	public bool MoveLeft(GameObject brick, bool updateSide)
	{
		if(directionChecker.CheckLeft(brick, gameModel.BrickArray) > 0)
		{
			BrickComponent brickComponent = brick.GetComponent<BrickComponent>();
			brickComponent.Location.x = brickComponent.Location.x - directionChecker.CheckLeft(brick, gameModel.BrickArray);
			//UpdateActualLocation(brickComponent.gameObject);
			if(updateSide == true)
			{
				brickComponent.Side = Sides.Left;
			}
			// Update the brick array so that everything is aligned.
			UpdateBrickArray();
			return true;
		}
		return false;
	}

	public bool MoveUp(GameObject brick, bool updateSide)
	{
		if(directionChecker.CheckUp(brick, gameModel.BrickArray) > 0)
		{
			BrickComponent brickComponent = brick.GetComponent<BrickComponent>();
			brickComponent.Location.y = brickComponent.Location.y + directionChecker.CheckUp(brick, gameModel.BrickArray);
			//UpdateActualLocation(brickComponent.gameObject);
			if(updateSide == true)
			{
				brickComponent.Side = Sides.Top;
			}
			// Update the brick array so that everything is aligned.
			UpdateBrickArray();
			return true;
		}
		return false;
	}

	public bool MoveDown(GameObject brick, bool updateSide)
	{
		if(directionChecker.CheckDown(brick, gameModel.BrickArray) > 0)
		{
			BrickComponent brickComponent = brick.GetComponent<BrickComponent>();
			brickComponent.Location.y = brickComponent.Location.y - directionChecker.CheckDown(brick, gameModel.BrickArray);
			//UpdateActualLocation(brickComponent.gameObject);
			if(updateSide == true)
			{
				brickComponent.Side = Sides.Bottom;
			}
			// Update the brick array so that everything is aligned.
			UpdateBrickArray();
			return true;
		}
		return false;
	}

	public bool UpdateBrickArray()
	{
		GameObject[,] newBrickArray = new GameObject[gameModel.PlayAreaWidth, gameModel.PlayAreaHeight];

		BrickComponent[] brickComponents = GetAllBricks();
		foreach(var brickComponent in brickComponents)
		{
			newBrickArray[(int)brickComponent.Location.x, (int)brickComponent.Location.y] = brickComponent.gameObject;
			// Each component figures out if it should be moving. This is BAD Entity Systems.
		}
		gameModel.BrickArray = newBrickArray;
		gameObject.GetComponent<DestroyProcessor>().FindAndDestroyObjects();
		return true;

	}

	public BrickComponent[] GetAllBricks()
	{
		BrickComponent[] obj = FindObjectsOfType<BrickComponent>();
		return obj;
	}
	
}
