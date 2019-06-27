using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public string firstScene;
    public string[] scenePool;

    protected SceneController() { }

    void Awake()
    {
        SceneManager.LoadScene(firstScene, LoadSceneMode.Additive);    
    }

    public void LoadGroupScene(string[] names)
    {
        for (int i = 0; i < names.Length; i++)
        {
            SceneManager.LoadScene(names[i], LoadSceneMode.Additive);  
        }
    }
}
