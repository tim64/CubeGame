using UnityEngine;
using System.Collections;

public class LocalPositionLock : MonoBehaviour {

	public bool EditVectorPoint = false;

	Vector3 startPos, mainPos, newPos;
	Transform parent;

	void Awake()
	{
		startPos = transform.localPosition;
		parent = transform.parent;

	} 

	void Update()
	{
		if (!EditVectorPoint) {
			mainPos = parent.position;
			newPos = new Vector3 (parent.position.x + startPos.x, parent.position.y + startPos.y);
			transform.position = newPos;
		}
	}
}
