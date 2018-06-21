using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockField : MonoBehaviour {

	public MovingWall wall;
    public ParticleSystem fieldFX;
    public ParticleSystem wallFX;

	public AudioSource soundFX;

	bool activation = false;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player" && !activation) {
			soundFX.Play();
			LeanTween.value (fieldFX.gameObject, UpdateFieldValue, fieldFX.emission.rateOverTime.constant, 0, 2).setOnComplete (delegate() {
				soundFX.Stop ();
			});

            LeanTween.value(wallFX.gameObject, UpdateWallValue, wallFX.emission.rateOverTime.constant, 100, 1).setOnComplete(delegate ()
            {
				soundFX.pitch = 0.5f;
				soundFX.Play();
				LeanTween.value(wallFX.gameObject, UpdateWallValue, wallFX.emission.rateOverTime.constant, 0, 1).setOnComplete (delegate() {
					soundFX.Stop ();
				});
            });

            activation = true;
			wall.Unlock ();
		}
	}

    void UpdateFieldValue (float value)
    {
        var em = fieldFX.emission;
        em.rate = value;
    }

    void UpdateWallValue(float value)
    {
        var em = wallFX.emission;
        em.rate = value;
    }
}
