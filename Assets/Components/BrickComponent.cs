using UnityEngine;
using System.Collections;

public class BrickComponent : MonoBehaviour 
{
	public Vector2 Location;
	public Color Color;
	public Sides Side;
	public int BrickGroup;
	public Shade Shade;

	private bool moving = false;
	private Vector2 startPos;
	private Vector2 endPos;
	private float timer = 0f;

	[SerializeField]
	private Material upDown;

	[SerializeField]
	private Material leftRight;


	void Awake()
	{
		int r = Random.Range(0,2);
//		Debug.Log(r);
		Shade = (Shade)r;
		BrickGroup = -1;
	}

	public BrickComponent()
	{

	}


	void Update()
	{
		AutoUpdateLocation();

//		SetColours();
		SetDirections();

	}

	private void AutoUpdateLocation ()
	{

		if(!moving && ((int)gameObject.transform.position.x != Location.x || (int)gameObject.transform.position.y != Location.y))
		{
			moving = true;
			timer = 1f;
		}

		if(moving)
		{
			//Debug.Log(timer);
			if(timer == 1f)
			{
				startPos = gameObject.transform.position;
				endPos = new Vector3(Location.x, Location.y);
				timer -=.1f;

			}
			else if(timer > 0)
			{
				gameObject.transform.position = Vector3.Lerp(endPos, startPos, timer);
				timer -= .32f;
			}
			else
			{
				gameObject.transform.position = new Vector3(Location.x, Location.y);
				moving = false;
				timer = 0f;
			}
		}
	}

	void SetColours ()
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

	void SetDirections ()
	{
		if(Side == Sides.Right || Side == Sides.Left)
		{
			BrickGroup = 0;
			gameObject.renderer.material = upDown;
		}
		else if (Side == Sides.Top || Side == Sides.Bottom)
		{
			BrickGroup = 1;
			gameObject.renderer.material = leftRight;
		}
	}
}
