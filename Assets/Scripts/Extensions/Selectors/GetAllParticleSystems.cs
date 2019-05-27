using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GetAllParticleSystems : MonoBehaviour
{

    public static int layer = 0;

    [MenuItem("Tools/Select all particle systems", false, 50)]
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
            ParticleSystem tr = t.GetComponent<ParticleSystem>();
            if (tr != null && t.activeSelf)
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