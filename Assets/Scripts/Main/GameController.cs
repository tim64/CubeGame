using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public FreeParallax parallax;

    void Start()
    {
        parallax.gameObject.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        LeanTween.reset();
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}