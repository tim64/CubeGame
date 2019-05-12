﻿using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 

public class TimerLabel:MonoBehaviour
{
    public bool stop = false; 
    public float time; 

    void Update()
    {
        if ( ! stop)
        {
            time += Time.deltaTime; 

            var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
var seconds = time % 60; //Use the euclidean division for the seconds.
var fraction = (time * 100) % 100; 

            //update the label value
            GetComponent < Text > ().text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction); 
        }
    }
}
