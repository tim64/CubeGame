using System.Collections;
using UnityEngine;

public class PositionLocker : MonoBehaviour
{

    private Vector2 startPosition;

    void Awake()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = startPosition;
    }
}