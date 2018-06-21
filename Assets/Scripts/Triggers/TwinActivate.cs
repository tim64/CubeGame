using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinActivate : MonoBehaviour {


    PlayerControl player;
    FaceControl face;
    void OnTriggerEnter2D(Collider2D coll) 
	{
        

        if (coll.gameObject.tag == "Player" )
		{
            face = coll.GetComponent<FaceControl>();
            player = coll.GetComponent<PlayerControl>();
            player.Twin = !player.Twin;
            Destroy(gameObject);
        }
	}
}
