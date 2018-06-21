using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMovingBlock : MonoBehaviour {

	public Transform moveToPoint;
	public GameObject safeWall;
	bool inMoving = false;
	bool wallActivated = false;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player" && !inMoving)
		{
			ActivateSafeWall ();
			inMoving = true;
			GameObject player = coll.gameObject;
			player.GetComponent<PlayerControl> ().forceControlOff = true;
			player.GetComponent<FaceControl> ().Normal ();
			player.GetComponent<Rigidbody2D> ().Sleep ();
			LeanTween.move (transform.parent.gameObject, moveToPoint.position, 15).setEase (LeanTweenType.easeInExpo);
					
		}
	}

	void ActivateSafeWall ()
	{
		if (!wallActivated) {
			LeanTween.move (safeWall, new Vector2 (safeWall.transform.position.x, safeWall.transform.position.y + 2f), 1).setEase (LeanTweenType.easeInExpo);
			wallActivated = true;
		}
	}
}
