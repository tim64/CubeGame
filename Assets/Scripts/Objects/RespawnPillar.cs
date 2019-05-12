using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class RespawnPillar:MonoBehaviour 
{

	public GameObject souleye; 
	public GameObject lines; 
	public Sprite color_sprite; 

	private void OnTriggerEnter2D(Collider2D other)
	{
		print(other.tag); 
		if (other.tag == "Player")
		{
			GetComponent < SpriteRenderer > ().sprite = color_sprite; 
			souleye.GetComponent < SpriteRenderer > ().color = Color.red; 
			lines.SetActive(true); 
		}
	}
}
