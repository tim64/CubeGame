using System.Collections;
using UnityEngine;

public class Linker : MonoBehaviour
{

    public Transform target;
    public Color color = Color.white;

    void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }
}