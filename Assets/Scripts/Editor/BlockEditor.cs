using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Block))]
public class BlockEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Block myScript = (Block)target;

        if (GUILayout.Button("Next sprite"))
        {
            myScript.NextSprite();
        }

        if (GUILayout.Button("Prew sprite"))
        {
            myScript.PrewSprite();
        }
    }
}