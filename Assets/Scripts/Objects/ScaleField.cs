﻿using UnityEngine;
using System.Collections;

public class ScaleField : MonoBehaviour {

	Vector2 objectSize;
	public AudioSource soundFX;

	GameObject scaledObject = null;
	[Header ("Scale persent")]
	[Range (0, 200)]
	public int delta;

	public enum ScaleDirection 
	{ 
		Increase, 
		Decrease 
	}
	[Header ("Scale direction")]
	public ScaleDirection direct = ScaleDirection.Decrease;

	void Start () 
	{
		objectSize = Vector2.zero;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (scaledObject == null && coll.gameObject.tag == "Player" && System.Math.Abs (delta) > 0) {
			
			PlayerControl player = coll.gameObject.GetComponent<PlayerControl> ();
			if (direct == ScaleDirection.Decrease) player.smallCube = true;
			else player.smallCube = false;

			//soundFX.Play ();

			scaledObject = coll.gameObject;
			objectSize = scaledObject.transform.localScale;
			LeanTween.scale (scaledObject, new Vector2 (objectSize.x * (0.01f * delta), objectSize.y * (0.01f * delta)), 0.5f).setEase (LeanTweenType.linear);
		}


	}
}