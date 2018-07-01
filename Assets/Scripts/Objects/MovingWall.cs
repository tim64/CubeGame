using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour {

	public int Yoffset = 0;
	public float movingTime = 0;
	public bool destroyAfrerMoving = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Unlock()
	{
		//GetComponent<RandomShake> ().enabled = true;
		LeanTween.moveLocalY (gameObject, transform.localPosition.y + Yoffset, movingTime).setDestroyOnComplete (destroyAfrerMoving);
	}
}
