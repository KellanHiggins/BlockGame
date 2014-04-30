using UnityEngine;
using System.Collections;

public class GameView : MonoBehaviour {

	public Material Material;
	public GameModel GameModel;
	public Color color = Color.red;
	public Rect StartRec;

	[SerializeField]

	void Awake()
	{
		GameModel = FindObjectOfType<GameModel>();
		StartRec = new Rect(Screen.width, Screen.height, 0f,0f);
	}

	void OnGUI()
	{
//		for(int y = 0; y < GameModel.PlayAreaHeight; y++)
//		{
//			for(int x = 0; x < GameModel.PlayAreaWidth; x++)
//			{
//				if(GameModel.BrickArray[x, y] != null)
//				{
//					Rect pos = new Rect(x * BrickWidth, y * BrickWidth, BrickWidth, BrickWidth);
//					DrawRectangle(pos, GameModel.BrickArray[x, y].BrickColour);
//				}
//			}
//		}


//		if(GameModel != null)
//		{
//			foreach(var key in GameModel.PositionAndBrickType.Keys)
//			{
//				Rect pos = new Rect((float)Util.ConvertPositionX(key) * BrickWidth, (float)Util.ConvertPositionY(key) * BrickWidth, BrickWidth, BrickWidth);
//				DrawRectangle(pos, GameModel.PositionAndBrickType[key].BrickColour);
//			}
//		}
	}

	void DrawRectangle (Rect position, Color color)
	{
		// We shouldn't draw until we are told to do so.
		if (Event.current.type != EventType.Repaint)
			return;
		
		// Please assign a material that is using position and color.
		if (Material == null) {
			Debug.LogError ("You have forgot to set a material.");
			return;
		}
		
		Material.SetPass(0);
		
		// Optimization hint:
		// Consider Graphics.DrawMeshNow

		GL.Begin (GL.QUADS);
		GL.Color(color);
		GL.Vertex3 (position.x, position.y, 0);
		GL.Vertex3 (position.x + position.width, position.y, 0);
		GL.Vertex3 (position.x + position.width, position.y + position.height, 0);
		GL.Vertex3 (position.x, position.y + position.height, 0);
		GL.End ();
	}
}
