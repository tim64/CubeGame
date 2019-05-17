using UnityEngine;
using UnityEditor;

public class GameDebug : MonoBehaviour
{
    [MenuItem("Game Debug/Reset Start Position %r")]
    private static void ResetStartPos()
    {
		GameObject.Find("Player Creator").transform.position = GameObject.Find("Start Position").transform.position;
    }
    
    [MenuItem("Game Debug/Set Start Position %g")]
    private static void SetStartPos()
    {
		GameObject.Find("Player Creator").transform.position = Selection.activeTransform.position + new Vector3(0, 2, 0);
		Selection.activeTransform = GameObject.Find("Player Creator").transform;
    }
    
    [MenuItem("Game Debug/Give double jump")]
    private static void GiveDoubleJump()
    {
		GameObject.Find("Player").GetComponent<PlayerControl>().DoubleJump = true;
    }
}
