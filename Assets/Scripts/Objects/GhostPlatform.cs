using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlatform : MonoBehaviour {

	public ParticleSystem particles;
	public AudioSource soundFX;


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			LeanTween.delayedCall (1, delegate() {
				soundFX.Play ();
				particles.Stop();
				LeanTween.alpha (gameObject, 1, 0.5f);
				GetComponent<PolygonCollider2D> ().isTrigger = false;
			});
		}
	}
}
