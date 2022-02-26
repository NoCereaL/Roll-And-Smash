using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterstitialSampleAds : MonoBehaviour
{
    public RectTransform LogoRectTransform;
    private void OnEnable()
    {
        if (Screen.height > Screen.width)
        {
            LogoRectTransform.anchorMin = new Vector2(0f, 0.5f);
            LogoRectTransform.anchorMax = new Vector2(1, 0.5f);
            LogoRectTransform.pivot = new Vector2(0.5f, 0.5f);
            LogoRectTransform.localScale = new Vector3(1, ((float)Screen.height / (float)Screen.width), 1);
            LogoRectTransform.offsetMin = Vector2.zero;
            LogoRectTransform.offsetMax = new Vector2(0,417);
            LogoRectTransform.localPosition = Vector3.zero;
        }
    }
    public void CloseInterstitialAds()
    {
        Yodo1EditorAds.CloseInterstitialAdsInEditor();
    }
}
