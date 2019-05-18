using UnityEngine;
using UnityEngine.PostProcessing;

public class DarkTrigger : MonoBehaviour
{
    public PostProcessingProfile postProcProf;
    public GameObject editorText;
    private PostProcessingProfile backup;
    private ColorGradingModel.Settings colorSettings;
    private float param;


    void Start()
    {
        editorText.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = false;

        backup = postProcProf;
        param = postProcProf.colorGrading.settings.basic.temperature;
        colorSettings = postProcProf.colorGrading.settings;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            LeanTween.value(gameObject, updateNewValue, 1, 50, 3);
        }
    }

    private void updateNewValue(float max)
    {
        param = max;
        colorSettings.basic.temperature = param;
        postProcProf.colorGrading.settings = colorSettings;
    }

    private void OnDestroy()
    {
        postProcProf = backup;
    }
}
