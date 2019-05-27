using System.Collections;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    public Vector2 lastPosition;
    public Transform respawnItem;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
            respawnItem = collision.transform;
    }

    public void Respawn()
    {
        rb.Sleep();
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        rb.position = respawnItem.transform.position;
    }
}