using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProcessingThunder : MonoBehaviour
{


    public PostProcessingProfile ppProfile;
    private float defaultBrightLevel = 3;

    void Awake()
    {
        StartCoroutine("ThunderOn");
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
        //copy current bloom settings from the profile into a temporary variable
        ColorGradingModel.Settings toneSetting = ppProfile.colorGrading.settings;

        //change the intensity in the temporary settings variable
        toneSetting.tonemapping.neutralWhiteLevel = bright;

        //set the bloom settings in the actual profile to the temp settings with the changed value
        ppProfile.colorGrading.settings = toneSetting;
    }
}
