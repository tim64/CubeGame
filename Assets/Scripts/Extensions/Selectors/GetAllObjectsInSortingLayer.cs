using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GetAllObjectsInSortingLayer : MonoBehaviour
{

    public static int layer = 0;

    [MenuItem("Tools/Select Objects in Render Layer Default", false, 50)]
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
            Renderer tr = t.GetComponent<SpriteRenderer>();
            if (tr != null && t.activeSelf)
                if (tr.sortingLayerID == layer)
                    Selected.Add(t);
        }
        Selection.objects = Selected.ToArray();

    }

    private static GameObject[] GetSceneObjects()
    {
        return Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.hideFlags == HideFlags.None).ToArray();
    }
}