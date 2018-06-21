using UnityEngine;
using UnityEditor;
using System.Collections;

public class RenameGameobjects : MonoBehaviour 
{
    static GameObject[] gameobjects; //array of all gameobjects in a scene

    public string gameobjectName;//Enter the name of the gameobject you want to rename the instances of
    public string newName; //Enter the name you want to rename the gameobjects to

    public static string nameOfObject; 
    public static string nameToChange; 

    void OnValidate()
    {
        nameOfObject = gameobjectName;
        nameToChange = newName;
    }

    [MenuItem("CONTEXT/RenameGameobjects/Rename GameObjects")]
    public static void Rename()
    {
        gameobjects = UnityEngine.Object.FindObjectsOfType<GameObject>(); //get all gameobjects in scene

        if (gameobjects != null)
        {
            for (int i = 0; i < gameobjects.Length; i++) //loop through all active gameobjects and change each name
            {
                if (gameobjects[i].activeInHierarchy)
                {
                    if (gameobjects[i].name.Contains(nameOfObject))
                    {
                        if (nameToChange != "")
                        {
                            gameobjects[i].name = nameToChange;
                        }
                    }
                }
            }
        }
    }
}
