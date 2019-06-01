using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject lightPoint;
    public GameObject rayFX;

    public bool lightOn = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !lightOn)
        {
            lightOn = true;
            rayFX.SetActive(true);
            lightPoint.SetActive(true);
        }
    }
}