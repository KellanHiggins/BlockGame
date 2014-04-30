using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;

public class _GameModelOLD : MonoBehaviour 
{
	/*
	public Dictionary<int, Brick> PositionAndBrickType { get; set; }

	[SerializeField]
	public List<Brick> LastTenItems;

	public int PlayAreaWidth;
	public int PlayAreaHeight;
	public bool debugOn = false;

	private int brickLocation;
	private int level = 0;
	private CurrentBrick currentActiveBrick;

	// Use this for initialization
	void Start () 
	{
		PositionAndBrickType = new Dictionary<int, Brick>();
		LastTenItems = new List<Brick>();
	}

	// We need to be able to add bricks to the center of the screen.
	public void AddNewPlayBrick()
	{
		int ranWidth = 0;
		int ranHeight = 0;

		ranWidth = Random.Range(-5, 5);
		ranHeight = Random.Range(-5, 5);

		AddInBrick((byte)(PlayAreaWidth/2 + ranWidth), (byte)(PlayAreaHeight/2 + ranHeight));
//		Debug.Log(currentActiveBrick.Brick + " " + currentActiveBrick.Location);
	}

	// We need to be able to move bricks 1 of 4 ways

	// We need to be able to move a brick all the way up
	public bool MoveBlock(MoveDirection moveDir)
	{
		int moveTo = 0;
		if(currentActiveBrick != null)
		{
			switch (moveDir)
			{
			case MoveDirection.Right:
				moveTo = CheckDirectionRight(currentActiveBrick.Location);
				break;
			case MoveDirection.Left:
				moveTo = CheckDirectionLeft(currentActiveBrick.Location);
				break;
			case MoveDirection.Up:
				moveTo = CheckDirectionUp(currentActiveBrick.Location);
				break;
			case MoveDirection.Down:
				moveTo = CheckDirectionDown(currentActiveBrick.Location);
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

			LastTenItems.Add(PositionAndBrickType[moveTo]);
			Debug.Log(LastTenItems.Count);
			CheckListLength();

			AddNewPlayBrick();
			return true;
		}
		return false;
	}

	void CheckListLength ()
	{
		if(LastTenItems.Count >= 10)
		{
			LastTenItems.RemoveAt(0);
		}
	}


	public bool AddInBrick(byte x, byte y)
	{
		brickLocation = Util.ConvertPosition(x, y);
		if(!PositionAndBrickType.ContainsKey(brickLocation))
		{
			PositionAndBrickType.Add(brickLocation, new Brick());
			currentActiveBrick = new CurrentBrick(brickLocation, PositionAndBrickType[brickLocation]);
			return true;
		}
		return false;

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
