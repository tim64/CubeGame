using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlip : MonoBehaviour {

    public float flipPeriod = 0.1f;
    public float randomFlipTime = 0.1f;

    void Start()
    {
        LeanTween.delayedCall(flipPeriod + Random.Range(-randomFlipTime, randomFlipTime), delegate () {
            GetComponent<Transform>().localScale = new Vector2(GetComponent<Transform>().localScale.x * (-1), GetComponent<Transform>().localScale.y);
        }).setLoopClamp();
    }
}
