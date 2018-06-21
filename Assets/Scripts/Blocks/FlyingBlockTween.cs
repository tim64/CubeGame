using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBlockTween : MonoBehaviour {

	public Transform pointer;
	public float time = 1;
	public float delay = 0;
	public LeanTweenType type = LeanTweenType.linear;
	public bool useLoop = false; 

	void Start () {
		if (pointer != null) {
			Vector2 pos = pointer.transform.position;
			LTDescr tween =  LeanTween.move(gameObject, pos, time).setEase(type).setDelay(delay);
			if (useLoop) tween.setLoopPingPong().setRepeat(-1);
		}
	}
}
