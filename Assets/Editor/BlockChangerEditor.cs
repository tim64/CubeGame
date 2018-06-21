using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BlockTextureGenerator))]
public class BlockChangerEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		BlockTextureGenerator myScript = (BlockTextureGenerator)target;
		if(GUILayout.Button("Generate"))
		{
			myScript.CreateTexture ();
		}
	}
}
