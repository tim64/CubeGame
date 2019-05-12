using UnityEngine; 

public class SoundExtension:MonoBehaviour 
{

	public static void PlayReverseSound(AudioSource snd)
	{
		snd.timeSamples = snd.clip.samples - 1; 
		snd.pitch = -1; 
		snd.volume = 0.1f; 
		snd.Play(); 
	}
}
