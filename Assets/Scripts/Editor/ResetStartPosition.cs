using UnityEngine;

public class ResetStartPosition : MonoBehaviour
{
    [UnityEditor.MenuItem("Utils/Reset Start Position", false, 3001)]
    private static void ResetStartPos()
    {
        GameObject.Find("Start Point").transform.position = new Vector2(-7, 47);
    }
}
