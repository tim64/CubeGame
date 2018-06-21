using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideRenderer : MonoBehaviour {

	SpriteRenderer render;

	void Awake()
	{
		render = GetComponent<SpriteRenderer>();
	}

    void Update () 
	{
		if (StaticAutoHide.IsVisibleToCamera(transform) == false)
			render.enabled = false;
		else
			GetComponent<SpriteRenderer>().enabled = true;
    }
}
