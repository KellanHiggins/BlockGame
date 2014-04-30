using UnityEngine;
using System.Collections;

public class BrickComponent : MonoBehaviour 
{
	public Vector2 Location;
	public Color Color;
	public Sides Side;
	public int BrickGroup;
	public Shade Shade;

	void Awake()
	{
		int r = Random.Range(0,2);
		Debug.Log(r);
		Shade = (Shade)r;
	}

	public BrickComponent()
	{

	}


	void Update()
	{
		if(Shade == Shade.Bright)
			gameObject.renderer.material.color = Color.white;
		else
			gameObject.renderer.material.color = Color.gray;

		switch(Side)
		{
		case Sides.Right:
			if(Shade == Shade.Bright)
				gameObject.renderer.material.color = Color.blue + new Color(0.2f, 0.2f, 0.2f);
			else
				gameObject.renderer.material.color = Color.blue;
			break;
		case Sides.Left:
			if(Shade == Shade.Bright)
				gameObject.renderer.material.color = Color.cyan + new Color(0.2f, 0.2f, 0.2f);
			else
				gameObject.renderer.material.color = Color.cyan;
			break;
		case Sides.Top:
			if(Shade == Shade.Bright)
				gameObject.renderer.material.color = Color.yellow + new Color(0.2f, 0.2f, 0.2f);
			else
				gameObject.renderer.material.color = Color.yellow;
			break;
		case Sides.Bottom:
			if(Shade == Shade.Bright)
				gameObject.renderer.material.color = Color.black + new Color(0.2f, 0.2f, 0.2f);
			else
				gameObject.renderer.material.color = Color.black;
			break;
		default:
			break;
		}
	}
}
