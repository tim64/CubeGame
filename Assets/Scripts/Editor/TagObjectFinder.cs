using UnityEngine; 
using UnityEngine.UI; 
using System.Collections; 
using System.Collections.Generic; 
using UnityEditor; 

class TagObjectFinder:EditorWindow 
{

	[MenuItem ("Utils/Tag Object Finder", false, 3001)]
	static void ShowWindow ()
    {
		EditorWindow.GetWindow < TagObjectFinder > (); 
	}

	string newName; 
	int currentTag, currentComponentType; 
	bool foldout = false; 
	bool[] includeInSelection; 

	System.Type[] componentTypes = 
    {
		typeof(Component), 		 
		typeof(SpriteRenderer), 
		typeof(TextMesh), 
		typeof(BoxCollider2D), 
		typeof(Rigidbody2D), 
		typeof(AudioSource), 
		typeof(RectTransform), 
		typeof(GridLayoutGroup), 
		typeof(Image), 
		typeof(Text), 
		typeof(Button), 
		typeof(Toggle), 
		typeof(Slider), 
		typeof(ScrollRect), 
	}; 
	string[] componentNames; 

	GameObject[] gosComp; 
	//Object[] components;
	List < GameObject > result; 
	List < GameObject > mSelection; 
	Vector2 scrollPos = Vector2.zero; 

	void OnEnable ()
    {
		result = new List < GameObject > (); 
		includeInSelection = null; 
		mSelection = new List < GameObject > (); 
		componentNames = new string[componentTypes.Length]; 
		componentNames[0] = "None"; 
		string tempString; 
		int tempIndex; 
		for (int i = 1; i < componentTypes.Length; i++)
        {
			tempString = componentTypes[i].ToString(); 
			tempIndex = tempString.LastIndexOf("."); 
			if (tempIndex > 0)
				componentNames[i] = tempString.Substring(tempIndex + 1); 
			else
				componentNames[i] = tempString; 
		}
	}

	void OnGUI ()
    {
		GUILayout.Space(10); 

		EditorGUI.BeginChangeCheck(); 

		currentTag = EditorGUILayout.Popup("Выберите тэг", currentTag, UnityEditorInternal.InternalEditorUtility.tags); 
		currentComponentType = EditorGUILayout.Popup("Выберите компонент", currentComponentType, componentNames); 

		if (EditorGUI.EndChangeCheck())
        {
			result.Clear(); 
			mSelection.Clear(); 
			includeInSelection = null; 
			if (currentComponentType != 0)
            {
				gosComp = Resources.FindObjectsOfTypeAll < GameObject > (); 
				foreach (GameObject go in gosComp)
                {
					if (go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave)
						continue; 

					if (EditorUtility.IsPersistent(go))
						continue; 

					if (go.GetComponent(componentTypes[currentComponentType]) != null)
                    {
						if (currentTag != 0 && go.tag != UnityEditorInternal.InternalEditorUtility.tags[currentTag])
							continue; 

						result.Add(go); 
					}
				}
				gosComp = null; 
			}
			else 
            {
				result.AddRange(GameObject.FindGameObjectsWithTag(UnityEditorInternal.InternalEditorUtility.tags[currentTag])); 
			}
		}
		GUILayout.Space(5); 
		if (GUILayout.Button("Выделить объекты на сцене") && result != null)
        {
			Selection.objects = result.ToArray(); 
			includeInSelection = new bool[result.Count]; 
			for (int i = 0; i < result.Count; i++)
            {
				includeInSelection[i] = true; 
				EditorGUIUtility.PingObject(Selection.objects [i]); 
			}
		}
		GUILayout.Space(5); 
		if (includeInSelection != null && includeInSelection.Length > 0)
        {
			mSelection.Clear(); 
			GUILayout.BeginHorizontal(); 
			{	
				GUILayout.Space(30); 
				if (GUILayout.Button ("All", GUILayout.Width(50)))
                {
					for (int i = 0; i < result.Count; i++)
						includeInSelection[i] = true; 
				}
				GUILayout.Space(10); 
				if (GUILayout.Button ("None", GUILayout.Width(50)))
                {
					for (int i = 0; i < result.Count; i++)
						includeInSelection[i] = false; 
				}
			}
			GUILayout.EndHorizontal(); 
			GUILayout.Space(5); 
			scrollPos = GUILayout.BeginScrollView (scrollPos); 
			EditorGUI.indentLevel++; 
			for (int i = 0; i < result.Count; i++)
            {
				includeInSelection[i] = EditorGUILayout.ToggleLeft(GetObjectHierarchyPath(result[i].transform), includeInSelection[i]); 
				if (includeInSelection [i])
                {
					mSelection.Add (result[i]); 
				}
			}
			EditorGUI.indentLevel--; 
			GUILayout.EndScrollView (); 
			// update selection
			Selection.objects = mSelection.ToArray(); 
		}
		GUILayout.Space(5); 
		GUILayout.Label("Найдено объектов: " + result.Count, EditorStyles.boldLabel); 
		GUILayout.Label("Выделено объектов: " + mSelection.Count, EditorStyles.boldLabel); 

		GUILayout.Space(10); 

		foldout = EditorGUILayout.Foldout(foldout, "Помощь"); 
		if (foldout)
        {
			GUILayout.Label(
				"Выделяются объекты с выбранным тэгом, имеющие при этом выбранный компонент.\n" + 
				"Если необходим поиск только по тэгу, поле компонента оставить 'None'.\n" + 
				"Если необходим поиск только по компоненту, поле тэга оставить 'Untagged'", EditorStyles.helpBox); 
		}

		this.Repaint(); 
	}

	string GetObjectHierarchyPath (Transform t)
    {		
		string s = "\b" + t.name + "\b"; 

		if (t.parent != null)
        {
			s = t.parent.name + "/" + s; 
			if (t.parent == t.root)
				return " " + s; 
		}
		else
			return " " + s; 

		if (t.parent.parent != null)
        {
			if (t.parent.parent == t.root)
            {
				s = t.root.name + "/" + s; 
				return " " + s; 
			}
			else 
            {
				s = t.root.name + "/~/" + s; 
			}
		}
		else
			return " " + s; 

		return " " + s; 
	}
}
