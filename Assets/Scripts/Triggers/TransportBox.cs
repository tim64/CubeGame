using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportBox : MonoBehaviour {

	public GameObject portal;
	public GameObject portal2;
	public GameObject ray;

	public AudioSource openPortalSound;
	public AudioSource raySound;
	public AudioSource gravitySound;
	public AudioSource scale;


	PlayerControl player;
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player")
		{
			player = coll.gameObject.GetComponent<PlayerControl> ();
			player.GetComponent<BoxCollider2D> ().enabled = false;
			player.GetComponent<Rigidbody2D> ().Sleep ();
			player.forceControlOff = true;
			player.transform.rotation = Quaternion.identity;

			gravitySound.Play ();
			LeanTween.move (player.gameObject, transform.position, 1);
			LeanTween.alpha (portal, 0, 3f).setDelay (0.5f);
			LeanTween.alpha (portal2, 0, 3f).setDelay (0.5f);
			openPortalSound.PlayDelayed (0.5f);

			LeanTween.scaleX(ray, 0.6f, 0.5f).setDelay (0.5f);
			raySound.PlayDelayed (0.5f);

			LeanTween.scale (player.gameObject, new Vector2 (0.6f, 0.6f), 1).setDelay (1);
			scale.PlayDelayed (1);

			LeanTween.moveLocalY (player.gameObject, player.transform.localPosition.y - 25, 3).setDelay (2).setOnComplete (delegate() {
				player.GetComponent<BoxCollider2D> ().enabled = true;
				SoundExtension.PlayReverseSound(scale);

				LeanTween.scale(player.gameObject, Vector2.one, 0.5f).setOnComplete(delegate() {
					LeanTween.scaleX(ray, 0f, 0.2f);
					SoundExtension.PlayReverseSound(scale);
					player.GetComponent<Rigidbody2D> ().WakeUp();
					player.forceControlOff = false;	
				});

			});
		}
	}
}
