using UnityEngine;
using System.Collections;

public class BrickComponent : MonoBehaviour 
{
	public Vector2 Location;
	public Color Color;
	public Sides Side;
	public int BrickGroup;

	public BrickComponent()
	{

	}


	void Update()
	{
		switch(Side)
		{
		case Sides.Right:
			gameObject.renderer.material.color = Color.blue;
			break;
		case Sides.Left:
			gameObject.renderer.material.color = Color.cyan;
			break;
		case Sides.Top:
			gameObject.renderer.material.color = Color.yellow;
			break;
		case Sides.Bottom:
			gameObject.renderer.material.color = Color.black;
			break;
		default:
			break;
		}
	}
}
