using UnityEngine;
using System.Collections;

public class DirectionChecker : MonoBehaviour {

	private GameModel gameModel;
	
	void Awake () 
	{
		gameModel = FindObjectOfType<GameModel>();
	}


	// TODO: Simplify this into just one function for all directions
	public int CheckRight(GameObject brick, GameObject[,] brickArray)
	{
		// Grab the brick's brickComponent
		BrickComponent brickComponent = brick.GetComponent<BrickComponent>();

		// First check if components are null
		if(brickComponent == null)
			return 0;
		
		// figure out the distance to the edge of the PlayArea
		int endOfPlayArea = (int)gameModel.PlayAreaWidth - (int)brickComponent.Location.x;
		int toMove = 0;
		
		// Calculate free spots to the right of it. The number starts at 1 cause that is where the box is.
		for(int x = 1; x < endOfPlayArea; x++)
		{
			if(brickArray[(int)brickComponent.Location.x + x, (int)brickComponent.Location.y] == null)
			{
				toMove += 1;
			}
			else
				break;
		}

		// If the brick doesn't move, return false
		if(toMove == 0)
			return 0;

		return toMove;
	}

	public int CheckLeft(GameObject brick, GameObject[,] brickArray)
	{
		// Grab the brick's brickComponent
		BrickComponent brickComponent = brick.GetComponent<BrickComponent>();
		
		// First check if components are null
		if(brickComponent == null)
			return 0;
		
		// figure out the distance to the edge of the PlayArea
		int endOfPlayArea = (int)brickComponent.Location.x;
		int toMove = 0;
		
		// Calculate free spots to the right of it. The number starts at 1 cause that is where the box is.
		for(int x = 1; x <= endOfPlayArea; x++)
		{
			if(brickArray[(int)brickComponent.Location.x - x, (int)brickComponent.Location.y] == null)
			{
				toMove += 1;
			}
			else
				break;
		}



		// If the brick doesn't move, return false
		if(toMove == 0)
		{
			return 0;
		}
//		Debug.Log("ToMove Number " + toMove);
		return toMove;
	}

	public int CheckUp(GameObject brick, GameObject[,] brickArray)
	{
		// Grab the brick's brickComponent
		BrickComponent brickComponent = brick.GetComponent<BrickComponent>();

		// First check if components are null
		if(brickComponent == null)
			return 0;
		
		// figure out the distance to the edge of the PlayArea
		int endOfPlayArea = (int)gameModel.PlayAreaHeight - (int)brickComponent.Location.y;
		int toMove = 0;
		
		// Calculate free spots to the right of it. The number starts at 1 cause that is where the box is.
		for(int y = 1; y < endOfPlayArea; y++)
		{
			if(brickArray[(int)brickComponent.Location.x, (int)brickComponent.Location.y + y] == null)
			{
				toMove += 1;
			}
			else
				break;
		}

		// If the brick doesn't move, return false
		if(toMove == 0)
		{
			return 0;
		}
		return toMove;
	}

	public int CheckDown(GameObject brick, GameObject[,] brickArray)
	{
		// Grab the brick's brickComponent
		BrickComponent brickComponent = brick.GetComponent<BrickComponent>();
		
		// First check if components are null
		if(brickComponent == null)
			return 0;
		
		// figure out the distance to the edge of the PlayArea
		int endOfPlayArea = (int)brickComponent.Location.y;
		int toMove = 0;
		
		// Calculate free spots to the right of it. The number starts at 1 cause that is where the box is.
		for(int y = 1; y <= endOfPlayArea; y++)
		{
			if(brickArray[(int)brickComponent.Location.x, (int)brickComponent.Location.y - y] == null)
			{
				toMove += 1;
			}
			else
				break;
		}
		
		// If the brick doesn't move, return false
		if(toMove == 0)
		{
			return 0;
		}
		return toMove;
	}
}
