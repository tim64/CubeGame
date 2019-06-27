using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    void Start()
    {
        LevelController.instance.LoadFirstLevel();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        LeanTween.reset();
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}