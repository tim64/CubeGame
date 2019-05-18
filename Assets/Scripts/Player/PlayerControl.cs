using UnityEngine; 
using System.Collections; 
using UnityEngine.EventSystems; 

public class PlayerControl:MonoBehaviour 
    {

	//Физические параметры
	Bounds playerBounds; 
	public int force = 100; 
    int forceX; 
    int forceY; 
    int direction = 1; 
    float boostX = 1.1f; 
    float boostY = 1.1f; 

    float speedX; 
    float speedY; 

	Rigidbody2D rb; 
	PlayerSoundController sndController; 
	public bool forceDisableControls = false; 
	public bool isGround = false; 

	FaceControl face; 
	public KeyCode jumpButton; 
	public Transform jumpVectorPoint; 
	public TrailRenderer doubleJumpFire;
    private bool doubleJump;
    public bool smallCube; 

    FreeParallax parallax;

    float speed; 
    bool doubleJumpMoment; 

    public float Speed
    {
        get
        {
            return Mathf.Max(Mathf.Abs(GetComponent < Rigidbody2D > ().velocity.x), Mathf.Abs(GetComponent < Rigidbody2D > ().velocity.y)); 
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
            if ( ! twin)
            {
                //face.ToEvil();
                GetComponent < SpriteRenderer > ().color = Color.red; 
            }
            else
            {
               // face.ToNormal();
                GetComponent < SpriteRenderer > ().color = Color.white; 
            }

            twin = value; 
        }
    }

    public bool DoubleJump
    {
        get
        {
            return doubleJump;
        }

        set
        {
            doubleJump = value;
            if (value)
            {
                force = 200;
            }
        }
    }

    private void Awake()
    {
        parallax = GameObject.Find("Parallax").GetComponent < FreeParallax > (); 
    }


    void Start ()
    {
        name = "Player"; 
        sndController = GetComponent < PlayerSoundController > (); 
        face = GetComponent < FaceControl > (); 
        rb = GetComponent < Rigidbody2D > (); 
        playerBounds = GetComponent < Renderer > ().bounds; 

        forceX = force; 
        forceY = force; 
    }

    void Update ()
	{
        //ПРЫГАЕМ ВПРАВО
        //Двойной прыжок
        // if (Input.GetKeyDown(KeyCode.RightArrow) &&  ! isGround &&  ! forceDisableControls && DoubleJump &&  ! DoubleJumpMoment)
        // {
        //     //Не дает делать двойные прыжки в воздухе
        //     direction = 1; 
        //     DoubleJumpMoment = true; 
        //     Jump (); 
        // }

        //Обычный прыжок
        if (Input.GetKeyDown(KeyCode.RightArrow) && isGround &&  ! forceDisableControls)
            {
            direction = 1; 
            Jump (); 
		}

        //ПРЫГАЕМ ВЛЕВО
        //Двойной прыжок
        // if (Input.GetKeyDown(KeyCode.LeftArrow) &&  ! isGround &&  ! forceDisableControls && doubleJump &&  ! doubleJumpMoment)
        // {
        //     //Не дает делать двойные прыжки в воздухе
        //     direction = -1; 
        //     doubleJumpMoment = true; 
        //     Jump(); 
        // }

        //Обычный прыжок
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isGround &&  ! forceDisableControls)
        {
            direction = -1; 
            Jump(); 
        }

        parallax.Speed = direction * rb.velocity.magnitude/10; 

    }

    public void ChangeRotateToDefault()
    {
        transform.rotation = Quaternion.identity; 
    }


    void Jump ()
	{
        //int tweendirection = 1;
        //if (twin) tweendirection = -1;

        face.Jump (); 
		if ( ! smallCube)
            {
			sndController.jump.pitch = Random.Range (0.6f, 1.2f); 
			sndController.jump.Play (); 
		}else 
            {
			sndController.jumpSmall.pitch = Random.Range (0.6f, 1.2f); 
			sndController.jumpSmall.Play (); 
		}

		//Двойные прыжки
        // if (DoubleJumpMoment)
        // {
        //     boostX = 1.5f; 
        //     boostY = 3; 
        // }
        //Прыжки миникуба
        if (smallCube)
        {
            boostX = 0.5f; 
            boostY = 1f; 
        }
        //Обычные прыжки
        if ( ! smallCube &&  ! DoubleJump)
        {
            boostX = 1.1f; 
            boostY = 1.1f; 
        }
        
        speedX = Mathf.Abs(jumpVectorPoint.localPosition.x) * force * direction; 
        speedY = Mathf.Abs(jumpVectorPoint.localPosition.y) * force; 

		rb.AddForce (new Vector2(speedX * boostX, speedY * boostY)); 

	}

	void OnCollisionEnter2D(Collision2D collision)
        {
		if (collision.gameObject.tag == "Blocks")
            {
			//DoubleJumpMoment = false; 
			isGround = true; 
			if (transform.localRotation.eulerAngles.z > 160 && transform.localRotation.eulerAngles.z < 200)
                {
				sndController.put2.Play (); 
				face.Bad (); 
			}else 
                {
				sndController.put.Play (); 
				face.Normal (); 
			}
		}

		if (collision.gameObject.tag == "Damager")
            {
			GetComponent < PlayerRespawner > ().Respawn (); 
		}
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Blocks")
            isGround = true; 
    }

    void OnCollisionExit2D(Collision2D collision)
        {
		if (collision.gameObject.tag == "Blocks")
			isGround = false; 
	}
	
	public void GetDoubleJump()
	{
		DoubleJump = true;
		doubleJumpFire.emitting = true;
	}
	
	public void RemoveDoubleJump()
	{
		DoubleJump = false;
		doubleJumpFire.emitting = false;
	}





}
