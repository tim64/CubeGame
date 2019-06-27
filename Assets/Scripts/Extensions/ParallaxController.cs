using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public PlayerControl player;
    public FreeParallax parallax;

    private Rigidbody2D playerRb;

    void Start()
    {
        playerRb  = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerRb != null)
            parallax.Speed = player.direction * playerRb.velocity.magnitude / 10;
    }
}
