using System.Collections;
using System.Collections.Generic;
using TurnTheGameOn.Timer;
using UnityEngine;

public class BaconFinish : MonoBehaviour
{
    public Timer timer;
    private bool activate = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !activate)
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            player.forceDisableControls = true;
            timer.StopTimer();
            activate = true;

            LeanTween.delayedCall(1, delegate ()
            {
                player.gameObject.SetActive(false);
            });
        }
    }
}