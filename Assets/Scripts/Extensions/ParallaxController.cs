using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public PlayerControl player;
    public FreeParallax parallax;
    public SpawnPointSystem spawnSystem;

    private Rigidbody2D playerRb;

    void Start()
    {
        parallax.gameObject.SetActive(true);
        EventManager.StartListening("PlayerCreated", ActivateParallax);
    }

    void ActivateParallax()
    {
        player = spawnSystem.player.GetComponent<PlayerControl>();
        playerRb  = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerRb != null)
            parallax.Speed = player.direction * playerRb.velocity.magnitude / 10;
    }
}
