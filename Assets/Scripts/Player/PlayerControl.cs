using UnityEngine;
using MathExtension;

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
                force = Constants.DOUBLEJUMP_FORCE;
            }
        }
    }

    public KeyCode jumpButton;
    public Transform jumpVectorPoint;
    public TrailRenderer doubleJumpFire;

    public int force = Constants.FORCE;
    private float boostX = Constants.NORMAL_BOOST_X;
    private float boostY = Constants.NORMAL_BOOST_Y;

    public int direction = 1;
    public bool forceDisableControls = false;
    public bool isGround = false;
    public bool smallCube;

    private bool doubleJumpMoment;
    private bool doubleJump;
    private int forceX;
    private int forceY;

    private float speedX;
    private float speedY;
    private float speed;
    float current_angle;

    private Bounds playerBounds;
    private Rigidbody2D rb;
    private PlayerSoundController sndController;
    private FaceControl face;

    void Start()
    {
        name = Constants.PLAYER_NAME;
        sndController = GetComponent<PlayerSoundController>();
        face = GetComponent<FaceControl>();
        rb = GetComponent<Rigidbody2D>();
        playerBounds = GetComponent<Renderer>().bounds;

        forceX = force;
        forceY = force;
    }

    void Update()
    {
        if (isGround && !forceDisableControls)
        {
            if (Input.GetKeyDown(Constants.CONTROL_RIGHT)) Jump(1);
            if (Input.GetKeyDown(Constants.CONTROL_LEFT)) Jump(-1);
        }
    }

    public void ChangeRotateToDefault()
    {
        transform.rotation = Quaternion.identity;
    }

    void Jump(int newDirection)
    {
        direction = newDirection;

        if (GetComponent<Rigidbody2D>() != null)
        {
            face.Jump();
            if (!smallCube)
            {
                sndController.jump.pitch = Random.Range(Constants.PITCH_JUMP_LEVEL / 2, Constants.PITCH_JUMP_LEVEL);
                sndController.jump.Play();
            }
            else
            {
                sndController.jumpSmall.pitch = Random.Range(Constants.PITCH_JUMP_LEVEL / 2, Constants.PITCH_JUMP_LEVEL);
                sndController.jumpSmall.Play();
            }

            if (smallCube)
            {
                boostX = Constants.SMALL_BOOST_X;
                boostY = Constants.SMALL_BOOST_Y;
            }

            if (!smallCube && !DoubleJump)
            {
                boostX = Constants.NORMAL_BOOST_X;
                boostY = Constants.NORMAL_BOOST_Y;
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
            current_angle = transform.localRotation.eulerAngles.z;
            isGround = true;

            bool check_angle = current_angle.IsWithin(Constants.MIN_SWAP_Z, Constants.MAX_SWAP_Z);

            if (check_angle)
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