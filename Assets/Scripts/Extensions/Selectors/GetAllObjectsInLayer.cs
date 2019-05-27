using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GetAllObjectsInLayer : MonoBehaviour
{

    public static int layer = 0;

    [MenuItem("Tools/Select Objects in Layer 0", false, 50)]
    public static void SelectObjectsInLayer()
    {
        var objects = GetSceneObjects();
        GetObjectsInLayer(objects, layer);
    }

    private static void GetObjectsInLayer(GameObject[] root, int layer)
    {
        List<GameObject> Selected = new List<GameObject>();
        foreach (GameObject t in root)
        {
            if (t.layer == layer && t.tag == "Untagged")
            {
                Selected.Add(t);
            }
        }
        Selection.objects = Selected.ToArray();

    }

    private static GameObject[] GetSceneObjects()
    {
        return Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.hideFlags == HideFlags.None).ToArray();
    }
}