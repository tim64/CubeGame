using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour {

	//Физические параметры
	Bounds playerBounds;
	public int force = 100;
    int forceX;
    int forceY;
    float boostX = 1;
    float boostY = 1;

    float speedX;
    float speedY;

	Rigidbody2D rb;
	PlayerSoundController sndController;
	public bool forceControlOff = false;
	public bool isGround = false;

	FaceControl face;
	public KeyCode jumpButton;
	public Transform jumpVectorPoint;
	public TrailRenderer fire;
    public bool doubleJump;
	public bool smallCube;

    float speed;
    bool doubleJumpMoment;

    public float Speed
    {
        get
        {
            return Mathf.Max(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x), Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
        }
    }


    bool twin;

    public bool Twin
    {
        get
        {
            return twin;
        }

        set
        {
            if (!twin)
            {
                //face.ToEvil();
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
               // face.ToNormal();
                GetComponent<SpriteRenderer>().color = Color.white;
            }

            twin = value;
        }
    }


    void Start ()
    {
        name = "Player";
        sndController = GetComponent<PlayerSoundController>();
        face = GetComponent<FaceControl>();
        rb = GetComponent<Rigidbody2D>();
        playerBounds = GetComponent<Renderer>().bounds;

        forceX = force;
        forceY = force;
    }

    void Update () 
	{
        //Двойной прыжок
        if (Input.GetKeyDown(jumpButton) && !isGround && !forceControlOff && doubleJump && !doubleJumpMoment)
        {
            //Не дает делать двойные прыжки в воздухе
            doubleJumpMoment = true;
            Jump ();
        }
        //Обычный прыжок
        if (Input.GetKeyDown(jumpButton) && isGround && !forceControlOff) {
			Jump ();
		}

    }

    void DoubleJump()
    {
        face.Jump();
        if (!smallCube)
        {
            sndController.jump.pitch = Random.Range(0.6f, 1.2f);
            sndController.jump.Play();
        }
        else
        {
            sndController.jumpSmall.pitch = Random.Range(0.6f, 1.2f);
            sndController.jumpSmall.Play();
        }
        rb.velocity = new Vector2(0, 0);


        rb.AddForce(new Vector2(jumpVectorPoint.localPosition.x * 4 * force, Mathf.Abs(jumpVectorPoint.localPosition.y) * 4 * force));

    }


    void Jump ()
	{
        int tweendirection = 1;
        if (twin) tweendirection = -1;

        face.Jump ();
		if (!smallCube) {
			sndController.jump.pitch = Random.Range (0.6f, 1.2f);
			sndController.jump.Play ();
		} else {
			sndController.jumpSmall.pitch = Random.Range (0.6f, 1.2f);
			sndController.jumpSmall.Play ();
		}
		//x100 y100 - default!
        if (doubleJumpMoment)
        {
            boostX = 1.5f;
            boostY = 3;
        }
        else
        {
            boostX = 1;
            boostY = 1;           
        }
        
        speedX = Mathf.Abs(jumpVectorPoint.localPosition.x) * force * tweendirection;
        speedY = Mathf.Abs(jumpVectorPoint.localPosition.y) * force;

		rb.AddForce (new Vector2(speedX * boostX, speedY * boostY));

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Blocks") {
			doubleJumpMoment = false;
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
