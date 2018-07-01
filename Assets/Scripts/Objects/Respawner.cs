using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

	bool resp = false;

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player" && !resp)
		{
			coll.GetComponent<PlayerRespawner> ().Respawn ();
			LeanTween.delayedCall (0.5f, () => resp = false);
		}
	}
}
