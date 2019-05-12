using UnityEngine; 

public class RespawnPillar:MonoBehaviour 
{

	public GameObject souleye; 
	public GameObject lines;
	public AudioSource respSound;
	public Sprite color_sprite; 

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			GetComponent < SpriteRenderer > ().sprite = color_sprite; 
			souleye.GetComponent < SpriteRenderer > ().color = Color.red;
			respSound.Play();
			lines.SetActive(true); 
		}
	}
}
