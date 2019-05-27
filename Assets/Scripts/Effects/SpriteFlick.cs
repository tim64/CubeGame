using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlick : MonoBehaviour
{
    [Range(0, 1)]
    public float frequency;

    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Run.Every(0, 1f * frequency, () => sprite.enabled = !sprite.enabled);
    }

}