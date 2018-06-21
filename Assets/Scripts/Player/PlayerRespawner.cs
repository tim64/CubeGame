using UnityEngine;
using System.Collections;

public class PlayerRespawner : MonoBehaviour {


	public Vector2 lastPosition;
	Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		lastPosition = new Vector2(-1.14f, -5.96f); //Позиция первого блока
	}

	//Сохраняем позицию при контакте с каждым вторым блоком
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground") {
			rb.WakeUp ();
			if (Vector2.Distance (lastPosition, coll.transform.position) > 10) {
				lastPosition = coll.transform.position;
			}
		}
	}

	public void Respawn()
	{
		rb.Sleep ();
		transform.localRotation = Quaternion.Euler(Vector3.zero);
		rb.MovePosition( new Vector2 (lastPosition.x + GetComponent<Renderer>().bounds.size.x, lastPosition.y + 10) );
	}
}
