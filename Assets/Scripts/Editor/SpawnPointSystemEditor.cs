using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnPointSystem)), CanEditMultipleObjects]
public class SpawnPointSystemEditor : Editor
{

    public SerializedProperty
    virtualCam_Prop,
    characterPrefab_Prop,
    portal_Prop,
    delaySpawn_Prop,
    appearType_Prop,
    tweenTime_Prop,
    startAngle_Prop,
    startColor_Prop;

    void OnEnable()
    {
        virtualCam_Prop = serializedObject.FindProperty("virtualCam");
        characterPrefab_Prop = serializedObject.FindProperty("characterPrefab");
        portal_Prop = serializedObject.FindProperty("portal");
        delaySpawn_Prop = serializedObject.FindProperty("delaySpawn");
        appearType_Prop = serializedObject.FindProperty("appearType");
        tweenTime_Prop = serializedObject.FindProperty("tweenTime");
        startAngle_Prop = serializedObject.FindProperty("startAngle");
        startColor_Prop = serializedObject.FindProperty("startColor");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(virtualCam_Prop);
        EditorGUILayout.PropertyField(characterPrefab_Prop);
        EditorGUILayout.PropertyField(portal_Prop);
        EditorGUILayout.PropertyField(delaySpawn_Prop);
        EditorGUILayout.PropertyField(appearType_Prop);

        SpawnPointSystem.AnimationType aType = (SpawnPointSystem.AnimationType)appearType_Prop.enumValueIndex;

        switch (aType)
        {
            case SpawnPointSystem.AnimationType.SCALE:
                EditorGUILayout.PropertyField(tweenTime_Prop, new GUIContent("tweenTime"));
                break;
            case SpawnPointSystem.AnimationType.TWIST:
                EditorGUILayout.PropertyField(tweenTime_Prop, new GUIContent("tweenTime"));
                EditorGUILayout.PropertyField(startAngle_Prop, new GUIContent("startAngle"));
                break;
            case SpawnPointSystem.AnimationType.ALPHA:
                EditorGUILayout.PropertyField(tweenTime_Prop, new GUIContent("tweenTime"));
                break;
            case SpawnPointSystem.AnimationType.COLOR:
                EditorGUILayout.PropertyField(tweenTime_Prop, new GUIContent("tweenTime"));
                EditorGUILayout.PropertyField(startColor_Prop, new GUIContent("startColor"));
                break;

                //case PropertyHolder.Status.B:
                //    EditorGUILayout.PropertyField(controllable_Prop, new GUIContent("controllable"));
                //    EditorGUILayout.IntSlider(valForAB_Prop, 0, 100, new GUIContent("valForAB"));
                //    break;

                //case PropertyHolder.Status.C:
                //    EditorGUILayout.PropertyField(controllable_Prop, new GUIContent("controllable"));
                //    EditorGUILayout.IntSlider(valForC_Prop, 0, 100, new GUIContent("valForC"));
                //    break;

        }

        serializedObject.ApplyModifiedProperties();
    }
}