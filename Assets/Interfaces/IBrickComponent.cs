using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IBrickComponent 
{

	void AddNewPlayBlock();
	void UpdateBrickLocation();
	void AddBrick(Vector2 location);

}
