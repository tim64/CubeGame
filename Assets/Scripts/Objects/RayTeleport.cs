using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTeleport : MonoBehaviour
{
    public GameObject endPoint;
    public GameObject playerFX;

    private float speed = 5;
    private  GameObject player;
    private bool activate;

    void Start() => endPoint.GetComponent<SpriteRenderer>().enabled = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll == null)
        {
            throw new ArgumentNullException(nameof(coll));
        }

        if (coll.tag == "Player" && !activate)
        {
            activate = true;
            player = coll.gameObject;

            DisablePlayerState();
            CreateFX();
            MoveToRay();
        }
    }

    private void MoveToRay() => LeanTween.move(player, new Vector3(transform.position.x, transform.position.y + 0.5f, 0), 1f).onComplete = FlyAction;

    private void FlyAction() => LeanTween.moveLocalY(gameObject: player, endPoint.transform.position.y, speed).onComplete = ActivatePlayerState;

    private void CreateFX()
    {
        playerFX.GetComponent<Renderer>().enabled = true;
        playerFX.transform.parent = player.gameObject.transform;
        playerFX.transform.localPosition = new Vector3(0, -1, 0);
        playerFX.transform.localScale = Vector3.one;
    }

    private void DisablePlayerState()
    {
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().Sleep();
        player.GetComponent<PlayerControl>().forceDisableControls = true;
        player.transform.rotation = Quaternion.identity;
    }

    private void RemoveFX()
    {
        playerFX.GetComponent<Renderer>().enabled = false;
        playerFX.transform.parent = gameObject.transform;
        playerFX.transform.localPosition = Vector3.zero;
        playerFX.transform.localScale = Vector3.one;
    }

    private void ActivatePlayerState()
    {
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<Rigidbody2D>().WakeUp();
        player.GetComponent<PlayerControl>().forceDisableControls = false;
        activate = false;
        RemoveFX();
    }
}
