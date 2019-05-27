using UnityEngine;

public class Tourch : MonoBehaviour
{
    public GameObject lightPoint;
    public GameObject rayFX;

    public bool on = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !on)
        {
            on = true;
            rayFX.SetActive(true);
            lightPoint.SetActive(true);
        }
    }
}