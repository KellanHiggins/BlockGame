using UnityEngine;
using System.Collections;

public class AutoDestroyComponent : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, 0.14f);
	}
}
