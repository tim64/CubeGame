using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpActivator : MonoBehaviour {


    private PlayerControl player;
    
	void OnTriggerEnter2D(Collider2D coll) 
	{
        

        if (coll.gameObject.tag == "Player" )
		{
            player = coll.GetComponent<PlayerControl>();
            player.doubleJump = true;
            Destroy(gameObject);
        }
	}
}
