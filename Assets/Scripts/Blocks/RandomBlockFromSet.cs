using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBlockFromSet : MonoBehaviour {

	public Sprite[] spriteSet;
	public bool useRandomFlip;

	SpriteRenderer renderer;

	void Start () {
		renderer = GetComponent<SpriteRenderer> ();

		renderer.sprite = spriteSet [Random.Range (0, (spriteSet.Length - 1))];
		if (useRandomFlip)
			renderer.flipX = Random.value > 0.5f;
	}
}
