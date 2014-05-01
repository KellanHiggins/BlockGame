using UnityEngine;
using System.Collections;

public class BrickTypeComponent : MonoBehaviour 
{
//	public Material GroupZeroLeftRight;
//	public Material GroupZeroUpDown;
//
//	public Material GroupOneLeftRight;
//	public Material GroupOneUpDown;
//
//	public Material GroupTwoLeftRight;
//	public Material GroupTwoUpDown;
//
//	public Material GroupThreeLeftRight;
//	public Material GroupThreeUpDown;

	private string textureToLoad = "none";



	public int BrickGroup;
	public Sides Side = Sides.None;

	void Awake()
	{
		int rand = Random.Range(0, 3);
		Debug.Log(rand);
		BrickGroup = rand;
		
//		SetColourByGroup();

		textureToLoad = "";
		SetDirectionForTexture();
	}

	public void SetDirectionForTexture()
	{
		switch(BrickGroup)
		{
		case 0:
			textureToLoad = "Zero";
			break;
		case 1:
			textureToLoad = "One";
			break;
		case 2:
			textureToLoad = "Two";
			break;
		case 3:
			textureToLoad = "Three";
			break;

		}

		if(Side == Sides.None)
		{
			textureToLoad = textureToLoad + "AllWays";
		}
		else if(Side == Sides.Left || Side == Sides.Right)
		{
			textureToLoad = textureToLoad + "UpDown";
		}
		else if(Side == Sides.Top || Side == Sides.Bottom)
		{
			textureToLoad = textureToLoad +"LeftRight";
		}

		gameObject.renderer.material.mainTexture = Resources.Load<Texture2D>(textureToLoad);
	}

	void Update()
	{
		// TODO: Call this once instead of all the time. No need to always call
		SetDirectionForTexture();
	}


//	void SetColourByGroup ()
//	{
//		switch(BrickGroup)
//		{
//		case 0:
//			gameObject.renderer.material.te
//			break;
//		case 1:
//			gameObject.renderer.material.color = new Color(0.8274f, 0.3294f, 0);
//			break;
//		case 2:
//			gameObject.renderer.material.color = new Color(0.8823f, 0.6274f, 0.5215f);
//			break;
//		default:
//			//gameObject.renderer.material.color = new Color(0f,0f,0f);
//			break;
//		}
//	}
}
