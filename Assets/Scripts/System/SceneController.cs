using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string firstScene;
    public string[] scenePool;

    void Awake()
    {
        SceneManager.LoadScene(firstScene, LoadSceneMode.Additive);    
    }
}
