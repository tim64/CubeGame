using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeLabel : MonoBehaviour {

    float currentTime = 0;

    public float CurrentTime
    {
        get
        {
            return PlayerPrefs.GetFloat("CurrentTime");
        }

        set
        {
            currentTime = value;
            PlayerPrefs.SetFloat("CurrentTime", value);
        }
    }

    void Start () {
        var minutes = CurrentTime / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = CurrentTime % 60;//Use the euclidean division for the seconds.
        var fraction = (CurrentTime * 100) % 100;

        GetComponent<Text>().text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);

    }

    // Update is called once per frame
    public void Recount(float newTime) {
        if (newTime > CurrentTime)
            CurrentTime = newTime;

        var minutes = CurrentTime / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = CurrentTime % 60;//Use the euclidean division for the seconds.
        var fraction = (CurrentTime * 100) % 100;

        //update the label value
        GetComponent<Text>().text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
    }
}
