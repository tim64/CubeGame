using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (SpriteRenderer sprite in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.enabled = true;
            sprite.sortingLayerName = "Fog" + sprite.name;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
