using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLines : MonoBehaviour {

    public Color color1;
    public Color color2;
    public float tweentime;
    public bool useRandomTime;

    SpriteRenderer line;

	void Start () {
        line = GetComponent<SpriteRenderer>();
        if (Random.Range(0, 2) == 0) line.color = color1; else line.color = color2;

        if (useRandomTime) tweentime = Random.Range(0.0f, tweentime);
        
       LeanTween.scaleY(gameObject, transform.localScale.y, tweentime).setFrom(0).setLoopPingPong();

    }
}
