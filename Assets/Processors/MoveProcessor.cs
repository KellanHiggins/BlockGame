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




	private IEnumerator SlideBlockSmoothly(BrickComponent brickComponent)
	{
		Vector3 startPos = brickComponent.gameObject.transform.position;
		Vector3 endPos = new Vector3(brickComponent.Location.x, brickComponent.Location.y);

		Debug.Log("Is this firing");
		for(float f = 0f; f <= 1f; f += 0.25f )
		{
			Debug.Log(f);
			//Debug.Log(f);
//			Debug.Log("The transform location" + brick.transform.position);
//			Debug.Log("The new position" + new Vector3(brickComponent.Location.x, brickComponent.Location.y));
			brickComponent.gameObject.transform.position = Vector3.Lerp(startPos, endPos, f);
			yield return 0;
		}
	}


	public bool UpdateBrickArray()
	{
		GameObject[,] newBrickArray = new GameObject[gameModel.PlayAreaWidth, gameModel.PlayAreaHeight];

		BrickComponent[] brickComponents = GetAllBricks();
		foreach(var brickComponent in brickComponents)
		{
			newBrickArray[(int)brickComponent.Location.x, (int)brickComponent.Location.y] = brickComponent.gameObject;
			//brickComponent.transform.position = new Vector3((float)brickComponent.Location.x, (float)brickComponent.Location.y);
			//StartCoroutine(SlideBlockSmoothly(brickComponent));
		}
		gameModel.BrickArray = newBrickArray;
		return true;

	}

	private bool UpdateActualLocation(GameObject brick)
	{
		// TODO:  We will be adding in movement here
		BrickComponent brickComponent = brick.GetComponent<BrickComponent>();
		if(brickComponent.Location.x != (int)brick.gameObject.transform.position.x || brickComponent.Location.y != (int)brick.gameObject.transform.position.y)
		{
			//StartCoroutine(SlideBlockSmoothly(brickComponent));
			//brick.transform.position = new Vector3(brickComponent.Location.x, brickComponent.Location.y);
			return true;
		}
		return false;
	}


	public BrickComponent[] GetAllBricks()
	{
		BrickComponent[] obj = FindObjectsOfType<BrickComponent>();
		return obj;
	}

//	public List<BrickComponent> GetAllBricksList()
//	{
//		for(int x = 0; x < gameModel.BrickArray.GetUpperBound(0); x++)
//		{
//			for(int y = 0; y < gameModel.BrickArray.GetUpperBound(1); y++)
//			{
//				
//			}
//		}
//		
//		
//		//BrickComponent[] obj = FindObjectsOfType<BrickComponent>();
//		return null;
//	}
}
