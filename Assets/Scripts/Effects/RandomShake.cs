using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class RandomShake:MonoBehaviour 
{

	public float shakeRadius = 0.1f; 
	public float randomPeriod = 0.1f; 
	public bool isMovingObject = false; 
	[Header("Offsets")]
	public float xOffset = 0; 
	public float yOffset = 0; 

	void Start ()
    {
		LeanTween.delayedCall (randomPeriod, delegate()
        {
			if (isMovingObject)
				transform.localPosition = transform.position + (Vector3)Random.insideUnitCircle * shakeRadius; 
			else
				transform.localPosition = transform.localPosition + (Vector3)Random.insideUnitCircle * shakeRadius; 
		}).setLoopClamp (); 
	}

}
