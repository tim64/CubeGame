using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarMove : MonoBehaviour {

    public float speed = 0.1f;
    public float step = 0.1f;
    public float patrolDistance = 1;

    private float walkDistance = 0;
    private int direction = 1;

    void Start()
    {
        //Move
        LeanTween.delayedCall(speed, delegate () {
            walkDistance += step;

            if (Mathf.Approximately(walkDistance, patrolDistance))
            {
                walkDistance = 0;
                step *= -1;
                patrolDistance *= -1;
                GetComponent<Transform>().localScale = new Vector2(GetComponent<Transform>().localScale.x * (-1), GetComponent<Transform>().localScale.y);
            }

            GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x + (step), GetComponent<Transform>().position.y);
        }).setLoopClamp();
    }
}
