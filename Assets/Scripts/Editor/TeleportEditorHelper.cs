using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GateTeleport))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GateTeleport myScript = (GateTeleport)target;
        if (GUILayout.Button("Move Camera to Exit"))
        {
            myScript.MoveCameraToNextPort();
        }
    }
}