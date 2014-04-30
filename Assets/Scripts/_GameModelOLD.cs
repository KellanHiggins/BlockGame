using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameModelOLD : MonoBehaviour 
{
/*




	public Brick[,] BrickArray;

	public Dictionary<int, Brick> PositionAndBrickType { get; set; }

	[SerializeField]
	public List<Brick> BrickList;

	public int PlayAreaWidth;
	public int PlayAreaHeight;
	public bool debugOn = false;

	private int brickLocation;
	private int level = 0;
	private CurrentBrick currentActiveBrick;

	// Use this for initialization
	void Start () 
	{
		BrickArray = new Brick[PlayAreaWidth,PlayAreaHeight];

		PositionAndBrickType = new Dictionary<int, Brick>();
		BrickList = new List<Brick>();
	}

	// We need to be able to add bricks to the center of the screen.
	public void AddNewPlayBrick()
	{
		int ranWidth = 0;
		int ranHeight = 0;

		ranWidth = UnityEngine.Random.Range(-5, 5);
		ranHeight = UnityEngine.Random.Range(-5, 5);

		AddInBrick((byte)(PlayAreaWidth/2 + ranWidth), (byte)(PlayAreaHeight/2 + ranHeight));
//		Debug.Log(currentActiveBrick.Brick + " " + currentActiveBrick.Location);
	}

	// We need to be able to move bricks 1 of 4 ways

	// We need to be able to move a brick all the way up
	public bool MoveBlock(MoveDirection moveDir)
	{
		int moveTo = 0;
		if(BrickList[0] != null)
		{
			switch (moveDir)
			{
			case MoveDirection.Right:
				moveTo = CheckDirectionRight(currentActiveBrick.Location);
				break;
			case MoveDirection.Left:
				//moveTo = CheckDirectionLeft(currentActiveBrick.Location);
				break;
			case MoveDirection.Up:
				//moveTo = CheckDirectionUp(currentActiveBrick.Location);
				break;
			case MoveDirection.Down:
				//moveTo = CheckDirectionDown(currentActiveBrick.Location);
				break;
			default:
				return false;
			}
		
			if(PositionAndBrickType.ContainsKey(moveTo))
				{
					return false;
				}
			PositionAndBrickType.Remove(currentActiveBrick.Location);
			PositionAndBrickType.Add(moveTo, new Brick());
			currentActiveBrick = null;

			BrickList.Add(PositionAndBrickType[moveTo]);
			Debug.Log(BrickList.Count);

			AddNewPlayBrick();
			return true;
		}
		return false;
	}

//	public bool MoveBlock(MoveDirection moveDir)
//	{
//		int moveTo = 0;
//		if(currentActiveBrick != null)
//		{
//			switch (moveDir)
//			{
//			case MoveDirection.Right:
//				moveTo = CheckDirectionRight(currentActiveBrick.Location);
//				break;
//			case MoveDirection.Left:
//				moveTo = CheckDirectionLeft(currentActiveBrick.Location);
//				break;
//			case MoveDirection.Up:
//				moveTo = CheckDirectionUp(currentActiveBrick.Location);
//				break;
//			case MoveDirection.Down:
//				moveTo = CheckDirectionDown(currentActiveBrick.Location);
//				break;
//			default:
//				return false;
//			}
//			
//			if(PositionAndBrickType.ContainsKey(moveTo))
//			{
//				return false;
//			}
//			PositionAndBrickType.Remove(currentActiveBrick.Location);
//			PositionAndBrickType.Add(moveTo, new Brick());
//			currentActiveBrick = null;
//			
//			LastTenItems.Add(PositionAndBrickType[moveTo]);
//			Debug.Log(LastTenItems.Count);
//			
//			AddNewPlayBrick();
//			return true;
//		}
//		return false;
//	}

	public bool AddInBrick(byte x, byte y)
	{
		if(BrickArray[x,y] == null)
		{
			BrickArray[x,y] = new Brick(true);
			BrickList.Insert(0, BrickArray[x,y]);
			return true;
		}
		return false;

	}

	public bool AddInBrick()
	{
		byte randX = (byte)UnityEngine.Random.Range(0, PlayAreaWidth);
		byte randY = (byte)UnityEngine.Random.Range(0, PlayAreaHeight);

		if(BrickArray[randX,randY] == null)
		{
			if(AddInBrick(randX, randY))
			{
				return true;
			}
		}
		return false;
		
	}

	private byte[] CheckDirectionRight(byte xLoc, byte yLoc)
	{
		byte[] returnLocation = new byte[2];

		byte slotsToRight = 0;
		int toEnd = (int)xLoc - PlayAreaWidth;
		// int slideLocation = 0;
		
		// If slots to the right of current position is open, move on and add plus
		for(byte b = 1; b < toEnd; b++)
		{
			if(BrickArray[xLoc + b, yLoc] != null)
			{
				slotsToRight += 1;
			}
			else
			{
				break;
			}
		}

		byte xLocation = 0;
		byte yLocation = 1;
		
		returnLocation[0] = (byte)(xLoc + slotsToRight);
		returnLocation[1] = yLoc;
		//Debug.Log(slideLocation);
		return returnLocation;
	}

	private int CheckDirectionLeft(int brickLocation)
	{
		byte slotsToLeft = 0;
		int toEnd = (int)Util.ConvertPositionX(brickLocation);
		int slideLocation = 0;
		
		// If slots to the right of current position is open, move on and add plus
		for(int i = 1; i < toEnd; i++)
		{
			if(!PositionAndBrickType.ContainsKey(Util.ConvertPosition((byte)(Util.ConvertPositionX(brickLocation) - (byte)i), Util.ConvertPositionY(brickLocation))))
			{
				slotsToLeft += 1;
			}
			else
			{
				break;
			}
		}
		
		slideLocation = Util.ConvertPosition((byte)(Util.ConvertPositionX(brickLocation) - slotsToLeft), Util.ConvertPositionY(brickLocation));
		//Debug.Log(slideLocation);
		return slideLocation;
	}

	private int CheckDirectionRight(int brickLocation)
	{
		byte slotsToRight = 0;
		int toEnd = PlayAreaWidth - (int)Util.ConvertPositionX(brickLocation);
		int slideLocation = 0;

		// If slots to the right of current position is open, move on and add plus
		for(int i = 1; i < toEnd; i++)
		{
			if(!PositionAndBrickType.ContainsKey(Util.ConvertPosition((byte)(Util.ConvertPositionX(brickLocation) + (byte)i), Util.ConvertPositionY(brickLocation))))
			{
				slotsToRight += 1;
			}
			else
			{
				break;
			}
		}

		slideLocation = Util.ConvertPosition((byte)(Util.ConvertPositionX(brickLocation) + slotsToRight), Util.ConvertPositionY(brickLocation));
		//Debug.Log(slideLocation);
		return slideLocation;
	}

	private int CheckDirectionUp(int brickLocation)
	{
		byte slots = 0;
		int toEnd = (int)Util.ConvertPositionY(brickLocation);
		int slideLocation = 0;
		
		// If slots to the right of current position is open, move on and add plus
		for(int i = 1; i < toEnd; i++)
		{
			if(!PositionAndBrickType.ContainsKey(Util.ConvertPosition(Util.ConvertPositionX(brickLocation), (byte)(Util.ConvertPositionY(brickLocation) - (byte)i))))
			{
				slots += 1;
			}
			else
			{
				break;
			}
		}
		
		slideLocation = Util.ConvertPosition(Util.ConvertPositionX(brickLocation), (byte)(Util.ConvertPositionY(brickLocation) - slots));
		//Debug.Log(slideLocation);
		return slideLocation;
	}

	private int CheckDirectionDown(int brickLocation)
	{
		byte slots = 0;
		int toEnd = PlayAreaHeight - (int)Util.ConvertPositionY(brickLocation);
		int slideLocation = 0;
		
		// If slots to the right of current position is open, move on and add plus
		for(int i = 1; i < toEnd; i++)
		{
			if(!PositionAndBrickType.ContainsKey(Util.ConvertPosition(Util.ConvertPositionX(brickLocation), (byte)(Util.ConvertPositionY(brickLocation) + (byte)i))))
			{
				slots += 1;
			}
			else
			{
				break;
			}
		}
		
		slideLocation = Util.ConvertPosition(Util.ConvertPositionX(brickLocation), (byte)(Util.ConvertPositionY(brickLocation) + slots));
//		Debug.Log(slideLocation);
		return slideLocation;
	}

	public void AddInCompletelyRandomBrick()
	{
		brickLocation = Util.ConvertPosition((byte)Random.Range(0, PlayAreaWidth), (byte)Random.Range(0, PlayAreaHeight));
		
		//AddInBrick();
	}*/
}
