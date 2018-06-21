using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnTheGameOn.Timer;

public class BaconFinish : MonoBehaviour {
	bool activate = false;
	public PortalEffect vortexEffect;
	public Timer timer;

	void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player" && !activate)
			{
				PlayerControl player = other.GetComponent<PlayerControl> ();
				player.forceControlOff = true;
				timer.StopTimer ();
				vortexEffect.TwistOpenTween ();
				activate = true;

				LeanTween.delayedCall (1, delegate() {
					vortexEffect.CloseTween ();
					player.gameObject.SetActive (false);
				});
			}
		}
}
