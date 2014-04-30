using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameModel : MonoBehaviour
{
	public int PlayAreaWidth;
	public int PlayAreaHeight;

	public PlayAreaEdges PlayAreaEdges;


	// Center is zero point. THEN, take the height and divide it by half so that we have the correcly
	// offset Play Area Width and Height.

	public GameObject BrickPrefab;
	public GameObject[,] BrickArray;
	public GameObject CurrentActiveBrick;

	public GameObject Processors;

	void Start () 
	{
		BrickArray = new GameObject[PlayAreaWidth,PlayAreaHeight];
		Processors = GameObject.Find("Processors");
		AddNewPlayBrick();

		PlayAreaEdges = new PlayAreaEdges();
		if(PlayAreaWidth % 2 == 0 && PlayAreaHeight %2 == 0)
		{
			// Sets the vector cordinates for the edge of the play area.
			PlayAreaEdges.TopPlayAreaEdge = PlayAreaHeight/2;
			PlayAreaEdges.BottomPlayAreaEdge = -(PlayAreaHeight/2);
			PlayAreaEdges.RightPlayAreaEdge = (PlayAreaWidth/2);
			PlayAreaEdges.LeftPlayAreaEdge = -(PlayAreaWidth/2);
		}
		else
			Debug.LogError("the area is not even");
		//		
		//		PositionAndBrickType = new Dictionary<int, Brick>();
		//		BrickList = new List<Brick>();
	}

	void Update()
	{
		for(int x = 0; x < PlayAreaWidth; x++)
		{
			for(int y = 0; y < PlayAreaHeight; y++)
			{
				if(CurrentActiveBrick == BrickArray[x,y])
				{
					CurrentActiveBrick.gameObject.renderer.material.color = Color.red;
				}
				else
				{
					if(BrickArray[x,y] != null)
					{
						BrickArray[x,y].gameObject.renderer.material.color = Color.gray;
					}
				}
			}
		}
	}

	public bool AddNewPlayBrick ()
	{
		Vector2 playAreaCenter = new Vector2(PlayAreaWidth/2, PlayAreaHeight/2);

		float x = (float)Random.Range(-2, 2);
		float y = (float)Random.Range(-2, 2);

		if(AddBrick(new Vector2(playAreaCenter.x + x, playAreaCenter.y + y)))
		{
			return true;
		}
		return false;
	}

	public bool AddBrick(Vector2 location)
	{
		float x = location.x;
		float y = location.y;

		if(BrickArray[(int)x, (int)y] == null)
		{
			GameObject newBrick = Instantiate(BrickPrefab, new Vector3(x, y), Quaternion.identity) as GameObject;
			newBrick.GetComponent<BrickComponent>().Location = new Vector2(x, y);
			BrickArray[(int)x, (int)y] = newBrick;
			CurrentActiveBrick = BrickArray[(int)x, (int)y];
			return true;
		}
		return false;
	}

	public void UpdateBrickLocation ()
	{
		Processors.GetComponent<MoveProcessor>().UpdateBrickArray();
	}

	public bool MoveNewBrick(MoveDirection moveDir)
	{
		DirectionChecker directionChecker = Processors.GetComponent<DirectionChecker>();

		switch (moveDir)
		{
		case MoveDirection.Right:
			if(directionChecker.CheckRight(CurrentActiveBrick, BrickArray) > 0)
			{
				MoveBrick(CurrentActiveBrick, MoveDirection.Right, true);
			}
			break;
		case MoveDirection.Left:
			if(directionChecker.CheckLeft(CurrentActiveBrick, BrickArray) > 0)
			{
				MoveBrick(CurrentActiveBrick, MoveDirection.Left, true);
			}
			break;
		case MoveDirection.Up:
			if(directionChecker.CheckUp(CurrentActiveBrick, BrickArray) > 0)
			{
				MoveBrick(CurrentActiveBrick, MoveDirection.Up, true);
			}
			break;
		case MoveDirection.Down:
			if(directionChecker.CheckDown(CurrentActiveBrick, BrickArray) > 0)
			{
				MoveBrick(CurrentActiveBrick, MoveDirection.Down, true);
			}
			break;
		default:
			break;
		}

		int i = 0;
		while(AddNewPlayBrick() != true)
		{
			AddNewPlayBrick();
			i++;
			
			if(i >= 256)
				break;
		}
		return true;
	}

	// We need to be able to move a brick all the way up
	public bool MoveBrick(GameObject brick, MoveDirection moveDir, bool updateBrickSide)
	{
		switch (moveDir)
		{
		case MoveDirection.Right:
			Processors.GetComponent<MoveProcessor>().MoveRight(brick, updateBrickSide);
			break;
		case MoveDirection.Left:
			Processors.GetComponent<MoveProcessor>().MoveLeft(brick, updateBrickSide);
			break;
		case MoveDirection.Up:
			Processors.GetComponent<MoveProcessor>().MoveUp(brick, updateBrickSide);
			break;
		case MoveDirection.Down:
			Processors.GetComponent<MoveProcessor>().MoveDown(brick, updateBrickSide);
			break; 
		default:
			return false;
		}
		return true;
	}
}
