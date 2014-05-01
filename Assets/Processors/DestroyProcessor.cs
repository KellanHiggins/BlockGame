using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyProcessor : MonoBehaviour 
{
	private GameModel gameModel;
//	GameObject[,] brickArray;

	void Awake () 
	{
		gameModel = FindObjectOfType<GameModel>();
//		brickArray = gameModel.BrickArray;
	}

	public void FindAndDestroyObjects ()
	{
		StartCoroutine(DestroyXObjects());
		StartCoroutine(DestroyYObjects());
	}

	IEnumerator DestroyXObjects ()
	{
		// Had to put this in because the system was processing this before it was finished
		yield return new WaitForEndOfFrame();
		List<int> RowsToDestroy = new List<int>();
		int destroyNumber = 0;

		for(int y = 0; y <= gameModel.BrickArray.GetUpperBound(1); y++)
		{
			for(int x = 0; x <= gameModel.BrickArray.GetUpperBound(0); x++)
			{
				if(destroyNumber >= 3)
				{
					RowsToDestroy.Add(y);
					break;
				}
				if(x == gameModel.BrickArray.GetUpperBound(0))
					continue;
				if(gameModel.BrickArray[x,y] == null || gameModel.BrickArray[x + 1, y] == null)
				{
					continue;
				}
				if(gameModel.BrickArray[x,y].GetComponent<BrickTypeComponent>().BrickGroup ==
				   gameModel.BrickArray[x + 1,y].GetComponent<BrickTypeComponent>().BrickGroup)
				{
					destroyNumber += 1;
				}
				else 
					destroyNumber = 0;
			}
			destroyNumber = 0;
		}

		DestroyListColoums(RowsToDestroy);
	}

	void DestroyListColoums(List<int> listOfRows)
	{
		foreach(var row in listOfRows)
		{
			for(int x = 0; x <= gameModel.BrickArray.GetUpperBound(0); x++)
			{
				//if(gameModel.BrickArray[x,row] != gameModel.CurrentActiveBrick)
					Destroy(gameModel.BrickArray[x,row], 2f);
			}
			Instantiate(gameModel.DestroyRow, new Vector3((float)gameModel.PlayAreaWidth / 2, row, 2f), Quaternion.identity);
		}
	}


	IEnumerator DestroyYObjects ()
	{
		// Had to put this in because the system was processing this before it was finished
		yield return new WaitForEndOfFrame();
		List<int> columnsToDestroy = new List<int>();
		int destroyNumber = 0;
		
		for(int x = 0; x <= gameModel.BrickArray.GetUpperBound(0); x++)
		{
			for(int y = 0; y <= gameModel.BrickArray.GetUpperBound(1); y++)
			{
				if(destroyNumber >= 3)
				{
					columnsToDestroy.Add(x);
					break;
				}
				if(y == gameModel.BrickArray.GetUpperBound(1))
					continue;
				if(gameModel.BrickArray[x,y] == null || gameModel.BrickArray[x, y + 1] == null)
				{
					continue;
				}
				if(gameModel.BrickArray[x,y].GetComponent<BrickTypeComponent>().BrickGroup ==
				   gameModel.BrickArray[x,y + 1].GetComponent<BrickTypeComponent>().BrickGroup)
				{
					destroyNumber += 1;
				}
				else 
					destroyNumber = 0;
			}
			destroyNumber = 0;
		}
		
		DestroyListColumns(columnsToDestroy);
	}
	
	void DestroyListColumns(List<int> listOfColumns)
	{
		foreach(var column in listOfColumns)
		{
			for(int y = 0; y <= gameModel.BrickArray.GetUpperBound(1); y++)
			{
				//if(gameModel.BrickArray[column,y] != gameModel.CurrentActiveBrick)
					Destroy(gameModel.BrickArray[column,y], 2f);
			}
			Instantiate(gameModel.DestroyColumn, new Vector3(column, (float)gameModel.PlayAreaHeight / 2, 2f), Quaternion.identity);
		}
	}
}
