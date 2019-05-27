using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogGenerator : MonoBehaviour
{

    void Start()
    {
        foreach (SpriteRenderer sprite in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.enabled = true;
            sprite.sortingLayerName = "Fog" + sprite.name;
        }

    }
}