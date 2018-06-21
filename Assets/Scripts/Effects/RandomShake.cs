using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShake : MonoBehaviour {

	public float shakeRadius = 0.1f;
	public float period = 0.1f;
	public bool isMovingObject = false;
	[Header("Offsets")]
	public float xOffset = 0;
	public float yOffset = 0;

	void Start () {
		LeanTween.delayedCall (period, delegate() {
			if (isMovingObject)
				transform.localPosition = new Vector3(xOffset, yOffset, 0) +  transform.localPosition +  (Vector3)Random.insideUnitCircle * shakeRadius;
			else
				transform.localPosition = new Vector3(xOffset, yOffset, 0) +   (Vector3)Random.insideUnitCircle * shakeRadius;
		}).setLoopClamp ();
		
	}

}
