using UnityEngine;
using System.Collections;

public class CurrentBrick
{
	public Brick Brick { get; set; }
	public int Location { get; set; }

	public CurrentBrick(int brickLocation, Brick brick)
	{
		Brick = brick;
		Location = brickLocation;
	}
}
