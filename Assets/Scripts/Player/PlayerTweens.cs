using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTweens : MonoBehaviour
{

    public void ScaleBouncing()
    {
        LeanTween.scaleY(gameObject, 0.9f, 0.4f).setDelay(0.5f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.scaleY(gameObject, 1f, 0.3f).setDelay(1f);
    }
}