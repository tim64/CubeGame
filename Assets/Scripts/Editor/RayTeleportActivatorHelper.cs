using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class RayTeleportActivatorHelper : Editor
{
    SerializedProperty listProperty;

    void OnEnable()
    {
        //listProperty = serializedObject.FindProperty("tourches");
    }

    public override void OnInspectorGUI()
    {
        //EditorGUI.PropertyField(new Rect(0, 300, 500, 30), listProperty, new GUIContent("List : "));

       // serializedObject.ApplyModifiedProperties();
    }
}
