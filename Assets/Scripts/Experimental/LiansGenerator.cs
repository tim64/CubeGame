using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiansGenerator : MonoBehaviour {


	private GameObject nextClone;

	void Start () 
	{
		LeanTween.scaleY(gameObject, 4, 1).setOnComplete(delegate() 
		{
			CreateClone();
			LeanTween.scaleX(nextClone, 4, 1).setOnComplete(delegate() 
			{
				CreateClone();
			});
		});
	}

	void CreateClone() 
	{
		GameObject clone = new GameObject();
		clone.AddComponent<SpriteRenderer>();
		clone.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
		clone.transform.parent = transform;
		clone.transform.localScale = Vector3.one;
		clone.transform.localPosition = Vector3.zero;
		nextClone = clone;
	}

}
