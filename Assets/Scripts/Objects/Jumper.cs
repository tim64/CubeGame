using UnityEngine; 
using System.Collections; 

public class Jumper:MonoBehaviour 
{

	public Transform targetAngle; 

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player" && targetAngle != null)
		{
			PlayerControl player = coll.gameObject.GetComponent < PlayerControl > (); 
			player.gameObject.GetComponent < Rigidbody2D > ().velocity = targetAngle.localPosition; 
		}
	}
}
