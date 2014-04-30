using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{

	public Color BrickColour { get; set; }
	public byte X { get; set; }
	public byte Y { get; set; }
	public bool IsCurrent { get; set; }
	public static int BrickId { get; set; }

	public Brick()
	{
		X = 0;
		Y = 0;
		BrickColour = Color.green;
		//BrickColour = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
	}

	public Brick(bool isCurrent)
	{
		X = 0;
		Y = 0;
		BrickColour = Color.green;
		IsCurrent = isCurrent;
	}

	public Brick(byte x, byte y)
	{
		X = x;
		Y = y;
		BrickColour = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
	}
}
