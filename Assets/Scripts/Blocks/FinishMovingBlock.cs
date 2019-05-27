using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class FinishMovingBlock : MonoBehaviour
{

    public Tourch fire1;
    public Tourch fire2;
    public GameObject blink;
    public BoxCollider2D trigger;
    public Transform moveToPoint;

    private bool inMoving = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !inMoving)
        {
            inMoving = true;
            GameObject player = coll.gameObject;

            player.GetComponent<PlayerControl>().forceDisableControls = true;
            player.GetComponent<FaceControl>().Normal();
            player.transform.rotation = Quaternion.identity;
            player.transform.parent = transform;
            Destroy(player.GetComponent<Rigidbody2D>());

            LeanTween.move(player, trigger.transform.position, 0.25f).setOnComplete(delegate ()
            {
                LeanTween.move(gameObject, moveToPoint.position, 3).setOnComplete(delegate ()
                {
                    LeanTween.scale(gameObject, new Vector2(0.3f, 0.3f), 0.25f);
                    LeanTween.scale(blink, new Vector2(5, 5), 0.3f).setFrom(Vector2.zero).setOnComplete(delegate ()
                    {
                        Camera.main.GetComponent<Camera2DFollow>().enabled = false;
                        LeanTween.scale(gameObject, new Vector2(0.01f, 0.01f), 0.3f);
                        LeanTween.moveX(gameObject, transform.position.x + 100, 1f);
                    });
                });
            });

        }
    }

    //TODO Переписать!
    static void ChangeTimers()
    {
        GameObject.Find("Timer").GetComponent<TimerLabel>().stop = true;
        GameObject.Find("BestTimer").GetComponent<BestTimeLabel>().Recount(GameObject.Find("Timer").GetComponent<TimerLabel>().time);
    }
}