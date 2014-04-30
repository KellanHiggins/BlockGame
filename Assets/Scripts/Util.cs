using UnityEngine;

public class Util : MonoBehaviour
{
	public static int ConvertPosition(byte x, byte y)
	{
		int newPos = 1000000;
		newPos = newPos + (int)x*1000;
		newPos = newPos + (int)y;
		return newPos;
	}
	
	public static byte ConvertPositionX(int pos)
	{
		int newPos = pos;
		newPos = newPos/1000;
		newPos = newPos - 1000;
		if(newPos < 255 && newPos >= 0)
		{
			return (byte)newPos;
		}
		Debug.Log("Position was returned incorrectly");
		return 255;
	}
	
	public static byte ConvertPositionY(int pos)
	{
		int newPos = pos;
		newPos -= (ConvertPositionX(pos)*1000);
		newPos -= 1000000;
		if(newPos < 255 && newPos >= 0)
		{
			return (byte)newPos;
		}
		Debug.Log("Position was returned incorrectly");
		return 255;
	}

}
