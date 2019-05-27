using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBlockFromSet : MonoBehaviour
{

    public Sprite[] spriteSet;
    public bool useRandomFlip;

    SpriteRenderer renderComponent;

    void Start()
    {
        renderComponent = GetComponent<SpriteRenderer>();

        renderComponent.sprite = spriteSet[Random.Range(0, (spriteSet.Length - 1))];
        if (useRandomFlip)
            renderComponent.flipX = Random.value > 0.5f;
    }
}