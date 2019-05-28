using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProcessingThunder : MonoBehaviour
{

    public PostProcessingProfile ppProfile;
    private float defaultBrightLevel = 3;

    public bool on = false;

    void Awake()
    {
        if (on == true) StartCoroutine("ThunderOn");
    }


    IEnumerator ThunderOn()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (Random.Range(0, 2) == 0)
            {
                ChangeBloomAtRuntime(1);
                LeanTween.delayedCall(0.1f, () => ChangeBloomAtRuntime(defaultBrightLevel));
                LeanTween.delayedCall(0.2f, () => ChangeBloomAtRuntime(1));
                LeanTween.delayedCall(0.6f, () => ChangeBloomAtRuntime(defaultBrightLevel));
            }

        }
    }

    void ChangeBloomAtRuntime(float bright)
    {
        ColorGradingModel.Settings toneSetting = ppProfile.colorGrading.settings;
        toneSetting.tonemapping.neutralWhiteLevel = bright;
        ppProfile.colorGrading.settings = toneSetting;
    }
}