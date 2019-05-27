using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    [Header("UI Elements")]
    public Button restart;
    public Button menu;
    public Text pause_text;
    public Image fade;
    [Header("_________")]
    public Transform restart_point;
    public Transform menu_point;
    public Transform pause_text_point;

    FaceControl face;
    SpriteRenderer faceSprite;
    Quaternion rotateBeforePause;
    bool isPaused = false;

    void Start()
    {
        restart = GameObject.Find("Restart").GetComponent<Button>();
        menu = GameObject.Find("Menu").GetComponent<Button>();
        fade = GameObject.Find("Fade").GetComponent<Image>();
        pause_text = GameObject.Find("PauseText").GetComponent<Text>();

        face = GetComponent<FaceControl>();
        faceSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PlayerPauseGame();

    }

    public void PlayerPauseGame()
    {
        if (!isPaused)
        {
            fade.enabled = true;
            rotateBeforePause = transform.rotation;
            transform.rotation = Quaternion.identity;
            isPaused = true;
            face.Pause();
            Time.timeScale = 0;
            faceSprite.sortingLayerName = "UI";

            ButtonControls(menu, true);
            ButtonControls(restart, true);
            pause_text.enabled = true;
            restart.transform.position = restart_point.position;
            menu.transform.position = menu_point.position;
            pause_text.transform.position = pause_text_point.position;
        }
        else
        {
            fade.enabled = false;
            transform.rotation = rotateBeforePause;
            isPaused = false;
            face.Normal();
            Time.timeScale = 1;
            faceSprite.sortingLayerName = "Player";

            ButtonControls(menu, false);
            ButtonControls(restart, false);
            pause_text.enabled = false;
        }
    }

    void ButtonControls(Button button, bool state)
    {
        button.GetComponent<Image>().enabled = state;
        button.enabled = state;
    }
}