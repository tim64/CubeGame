using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using MorePPEffects; 

public class Tourch:MonoBehaviour 
    {

	//public GameObject light;
	//public ParticleSystem particles;
	public Sprite lightOnSprite; 
	public bool on = false; 

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player" &&  ! on)
		{
			on = true; 
			//1.33 0.98 1.08
			//Camera.main.GetComponent<Colorization>().Rchannel += 0.25f;
			//Camera.main.GetComponent<Colorization>().Gchannel += 0.25f;
			//Camera.main.GetComponent<Colorization>().Bchannel += 0.25f;
			GetComponent < SpriteRenderer > ().sprite = lightOnSprite; 
			//particles.gameObject.SetActive (true);
			//light.SetActive (true);
		}
	}
}
