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
			UpdateActualLocation(brickComponent.gameObject);
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
			UpdateActualLocation(brickComponent.gameObject);
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
			UpdateActualLocation(brickComponent.gameObject);
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
			UpdateActualLocation(brickComponent.gameObject);
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


	private bool UpdateActualLocation(GameObject brick)
	{
		// TODO:  We will be adding in movement here
		BrickComponent brickLocation = brick.GetComponent<BrickComponent>();
		if(brickLocation.Location.x != (int)brick.gameObject.transform.position.x || brickLocation.Location.y != (int)brick.gameObject.transform.position.y)
		{
			brick.transform.position = new Vector3(brickLocation.Location.x, brickLocation.Location.y);
			return true;
		}
		return false;
	}


	public bool UpdateBrickArray()
	{
		GameObject[,] newBrickArray = new GameObject[gameModel.PlayAreaWidth, gameModel.PlayAreaHeight];

		BrickComponent[] bricks = GetAllBricks();
		foreach(var brick in bricks)
		{
			newBrickArray[(int)brick.Location.x, (int)brick.Location.y] = brick.gameObject;
			brick.transform.position = new Vector3((float)brick.Location.x, (float)brick.Location.y);
		}
		gameModel.BrickArray = newBrickArray;
		return true;

	}

	public BrickComponent[] GetAllBricks()
	{
		BrickComponent[] obj = FindObjectsOfType<BrickComponent>();
		return obj;
	}
}
