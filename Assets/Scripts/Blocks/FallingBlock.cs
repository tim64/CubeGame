using System.Collections;
using UnityEngine;

public class FallingBlock : Block
{

    public override void Start()
    {
        base.Start();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            rb.mass = 0f;
            rb.isKinematic = false;
        }
    }
}