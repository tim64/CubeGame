using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAutoHide : MonoBehaviour
{

    public static bool IsVisibleToCamera(Transform transform)
    {
        Vector3 visTest = Camera.main.WorldToViewportPoint(transform.position);
        return (visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1 && visTest.y <= 1) && visTest.z >= 0;
    }
}