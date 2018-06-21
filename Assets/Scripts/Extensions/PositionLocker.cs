using UnityEngine;
using System.Collections;

public class PositionLocker : MonoBehaviour {

	Vector2 startPosition;

	void Awake () 
	{
		startPosition = transform.position;
	}

	void Update () 
	{
		transform.position = startPosition;
	}
}
