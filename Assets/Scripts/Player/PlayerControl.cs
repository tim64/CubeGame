using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour {

	//Физические параметры
	Bounds playerBounds;
	public int force = 100;

	Rigidbody2D rb;
	PlayerSoundController sndController;
	public bool forceControlOff = false;
	public bool isGround = false;

	FaceControl face;
	public KeyCode jumpButton;
	public Transform jumpVectorPoint;
	public TrailRenderer fire;
	public bool smallCube;

	void Start ()
    {
        name = "Player";
        sndController = GetComponent<PlayerSoundController>();
        face = GetComponent<FaceControl>();
        rb = GetComponent<Rigidbody2D>();
        playerBounds = GetComponent<Renderer>().bounds;
    }

    void Update () 
	{
		if (Input.GetKeyDown(jumpButton) && isGround && !forceControlOff) {
			Jump ();
		}
    }

	void Jump ()
	{
		face.Jump ();
		if (!smallCube) {
			sndController.jump.pitch = Random.Range (0.6f, 1.2f);
			sndController.jump.Play ();
		} else {
			sndController.jumpSmall.pitch = Random.Range (0.6f, 1.2f);
			sndController.jumpSmall.Play ();
		}
		//x100 y100 - default!
		rb.AddForce (new Vector2 (Mathf.Abs(jumpVectorPoint.localPosition.x) * force, Mathf.Abs(jumpVectorPoint.localPosition.y) * force));
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Blocks") {
			
			isGround = true;
			if (transform.localRotation.eulerAngles.z > 160 && transform.localRotation.eulerAngles.z < 200) {
				sndController.put2.Play ();
				face.Bad ();
			} else {
				sndController.put.Play ();
				face.Normal ();
			}
		}

		if (coll.gameObject.tag == "Damager") {
			GetComponent<PlayerRespawner> ().Respawn ();
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Blocks")
			isGround = false;
	}





}
