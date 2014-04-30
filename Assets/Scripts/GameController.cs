using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public GameModel GameModel;
	public GameObject Processors;

	void Start () 
	{
		GameModel = FindObjectOfType<GameModel>();
		Processors = GameObject.Find("Processors");
	}


	
	void Update () 
	{
		if(Input.GetKey(KeyCode.F) == true)
		{
			GameModel.AddNewPlayBrick();
		}


		MoveNewBricks();
		MovePlacedBricks();

	}

	// Probs redundant
//	private MoveDirection GetDirection(MoveDirection moveDir)
//	{
//		switch(moveDir){
//		case MoveDirection.Up:
//			return MoveDirection.Up;
//			break;
//		case MoveDirection.Down:
//			return MoveDirection.Down;
//			break;
//		case MoveDirection.Left:
//			return MoveDirection.Left;
//			break;
//		case MoveDirection.Right:
//			return MoveDirection.Right;
//			break;
//		default:
//			return MoveDirection.None;
//			break;
//		}
//	}

	private void MoveNewBricks ()
	{
		// This shouldn't be doing any of the calculations. That should all be in GameModel.
		// TODO: Change so this just sends commands to the GameModel

		if(Input.GetKeyDown(KeyCode.RightArrow) == true)
		{
			GameModel.MoveNewBrick(MoveDirection.Right);
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow) == true)
		{
			GameModel.MoveNewBrick(MoveDirection.Left);
		}
		else if(Input.GetKeyDown(KeyCode.UpArrow) == true)
		{
			GameModel.MoveNewBrick(MoveDirection.Up);
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow) == true)
		{
			GameModel.MoveNewBrick(MoveDirection.Down);
		}
	}

	void MovePlacedBricks ()
	{
		if(Input.GetKeyDown(KeyCode.W) == true)
		{
			Processors.GetComponent<MoveSidesProcessor>().Move(GameModel.BrickArray, MoveDirection.Up);
		}
		if(Input.GetKeyDown(KeyCode.S) == true)
		{
			Processors.GetComponent<MoveSidesProcessor>().Move(GameModel.BrickArray, MoveDirection.Down);
		}
		if(Input.GetKeyDown(KeyCode.A) == true)
		{
			Processors.GetComponent<MoveSidesProcessor>().Move(GameModel.BrickArray, MoveDirection.Left);
		}
		if(Input.GetKeyDown(KeyCode.D) == true)
		{
			Processors.GetComponent<MoveSidesProcessor>().Move(GameModel.BrickArray, MoveDirection.Right);
		}
	}
}






























