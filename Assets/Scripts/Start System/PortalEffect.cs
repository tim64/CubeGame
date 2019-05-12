using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class PortalEffect:MonoBehaviour 
    {

	public AudioSource openSound; 

	public void TwistOpenTween()
	{
		openSound.Play (); 
		LeanTween.alpha (gameObject, 1f, 1f); 
		LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 1f).setEase(LeanTweenType.easeInOutElastic).setFrom(Vector3.zero); 
		LeanTween.rotateAround(gameObject, new Vector3(0f, 0f, -1f), 180f, 0.5f).setDelay(1f); 
	}

	public void CloseTween()
	{
		SoundExtension.PlayReverseSound (openSound); 
		LeanTween.scale (gameObject, new Vector3 (0f, 0f, 0f), 1f).setEase (LeanTweenType.easeInOutExpo).setFrom (Vector3.one); 
	}
}
