using UnityEngine;
using System.Collections;

public class GateTeleport : MonoBehaviour {

	public Transform teleportPoint;

	public AudioSource teleportSound;

	void Start()
	{

		if (teleportPoint == null)
			Destroy (this);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player")
		{
			GameObject player = coll.gameObject;
			teleportSound.Play ();

			LeanTween.scale (player, Vector3.zero, 0.5f).setOnComplete (delegate() {
				Camera.main.transform.position = teleportPoint.position;
				player.GetComponent<Rigidbody2D> ().MovePosition(teleportPoint.position);

				LeanTween.value (gameObject, UpdateVolume, teleportSound.volume, 0, 1.5f).setOnComplete (delegate() {
					teleportSound.Stop ();
				});

				LeanTween.scale (player, Vector3.one, 1f).setFrom(Vector3.zero);
			});
					
		}
	}

	void UpdateVolume (float value)
	{
		teleportSound.volume = value;
	}
}
