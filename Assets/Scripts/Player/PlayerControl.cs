using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{

    public float Speed
    {
        get
        {
            return Mathf.Max(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x), Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
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

    public KeyCode jumpButton;
    public Transform jumpVectorPoint;
    public TrailRenderer doubleJumpFire;

    public int force = 100;
    public int direction = 1;
    public bool forceDisableControls = false;
    public bool isGround = false;
    public bool smallCube;

    private bool doubleJumpMoment;
    private bool doubleJump;
    private int forceX;
    private int forceY;
    private float boostX = 1.1f;
    private float boostY = 1.1f;
    private float speedX;
    private float speedY;
    private float speed;

    private Bounds playerBounds;
    private Rigidbody2D rb;
    private PlayerSoundController sndController;
    private FaceControl face;
    //private FreeParallax parallax;
    

    // private void Awake()
    // {
    //     parallax = GameObject.Find("Parallax").GetComponent<FreeParallax>();
    // }

    void Start()
    {
        name = "Player";
        sndController = GetComponent<PlayerSoundController>();
        face = GetComponent<FaceControl>();
        rb = GetComponent<Rigidbody2D>();
        playerBounds = GetComponent<Renderer>().bounds;

        forceX = force;
        forceY = force;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) && isGround && !forceDisableControls)
        {
            direction = 1;
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && isGround && !forceDisableControls)
        {
            direction = -1;
            Jump();
        }

        // if (GetComponent<Rigidbody2D>() != null)
        //     parallax.Speed = direction * rb.velocity.magnitude / 10;

    }

    public void ChangeRotateToDefault()
    {
        transform.rotation = Quaternion.identity;
    }

    void Jump()
    {
        if (GetComponent<Rigidbody2D>() != null)
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

            if (smallCube)
            {
                boostX = 0.5f;
                boostY = 1f;
            }
            //Обычные прыжки
            if (!smallCube && !DoubleJump)
            {
                boostX = 1.1f;
                boostY = 1.1f;
            }

            speedX = Mathf.Abs(jumpVectorPoint.localPosition.x) * force * direction;
            speedY = Mathf.Abs(jumpVectorPoint.localPosition.y) * force;

            rb.AddForce(new Vector2(speedX * boostX, speedY * boostY));
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Blocks")
        {
            //DoubleJumpMoment = false; 
            isGround = true;
            if (transform.localRotation.eulerAngles.z > 160 && transform.localRotation.eulerAngles.z < 200)
            {
                sndController.put2.Play();
                face.Bad();
            }
            else
            {
                sndController.put.Play();
                face.Normal();
            }
        }

        if (collision.gameObject.tag == "Damager")
        {
            GetComponent<PlayerRespawner>().Respawn();
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