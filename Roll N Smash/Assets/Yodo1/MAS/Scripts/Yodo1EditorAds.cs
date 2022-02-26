using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Yodo1.MAS;

public class Yodo1EditorAds : MonoBehaviour
{
    public static GameObject AdHolder;
    public static GameObject BannerSampleAdEditor;
    private static GameObject InterstitialSampleAdEditor;
    private static GameObject RewardedVideoSampleAdEditor;

    public static bool DisableGUI = false;
    public static bool GrantReward = false;
    public static void InitializeAds()
    {
        EventSystem sceneEventSystem = FindObjectOfType<EventSystem>();
        if (sceneEventSystem == null)
        {
            AdHolder = Instantiate(Resources.Load("SampleAds/AdHolder") as GameObject);
        }
        if (BannerSampleAdEditor == null)
        {
            BannerSampleAdEditor = Instantiate(Resources.Load("SampleAds/BannerSampleAdPanel") as GameObject, GameObject.Find("Canvas").transform);
        }
        if (InterstitialSampleAdEditor == null)
        {
            InterstitialSampleAdEditor = Instantiate(Resources.Load("SampleAds/InterstitialSampleAdPanel") as GameObject, GameObject.Find("Canvas").transform);
        }
        if (RewardedVideoSampleAdEditor == null)
        {
            RewardedVideoSampleAdEditor = Instantiate(Resources.Load("SampleAds/RewardedVideoSampleAdPanel") as GameObject, GameObject.Find("Canvas").transform);
        }
    }

    
    public static void ShowBannerAdsInEditor()
    {
        if (BannerSampleAdEditor != null)
        {
            BannerSampleAdEditor.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1f);
            BannerSampleAdEditor.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1f);
            BannerSampleAdEditor.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
            BannerSampleAdEditor.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
            BannerSampleAdEditor.SetActive(true);
            Debug.Log(Yodo1U3dMas.TAG + "Editor Banner ad opened");

        }
    }
    private static float anchorMinX, anchorMinY, anchorMaxX, anchorMaxY, pivotX, pivotY, anchoredPositionX, anchoredPositionY;
    public static int tempAlign = 0;
    public static void ShowBannerAdsInEditor(int align)
    {
        if (align == 0)
        {
            align = tempAlign;
        }
        tempAlign = align;

        if (BannerSampleAdEditor != null)
        {
            anchorMinX = 0.5f;
            anchorMinY = 1f;
            anchorMaxX = 0.5f;
            anchorMaxY = 1f;
            pivotX = 0.5f;
            pivotY = 1f;
            anchoredPositionX = 0f;
            anchoredPositionY = 0f;
            if ((align & (int)Yodo1U3dBannerAdPosition.BannerHorizontalCenter) == (int)Yodo1U3dBannerAdPosition.BannerHorizontalCenter)
            {
                anchorMinX = 0.5f;
                anchorMaxX = 0.5f;
                pivotX = 0.5f;
                anchoredPositionX = 0f;
                
            }
            else if ((align & (int)Yodo1U3dBannerAdPosition.BannerRight) == (int)Yodo1U3dBannerAdPosition.BannerRight)
            {
                anchorMinX = 1f;
                anchorMaxX = 1f;
                pivotX = 0.5f;
                anchoredPositionX = -320f;
            }
            else if ((align & (int)Yodo1U3dBannerAdPosition.BannerLeft) == (int)Yodo1U3dBannerAdPosition.BannerLeft)
            {
                anchorMinX = 0f;
                anchorMaxX = 0f;
                pivotX = 0.5f;
                anchoredPositionX = 320f;
            }

            if ((align & (int)Yodo1U3dBannerAdPosition.BannerVerticalCenter) == (int)Yodo1U3dBannerAdPosition.BannerVerticalCenter)
            {
                anchorMinY = 0.5f;
                anchorMaxY = 0.5f;
                pivotY = 0f;
                anchoredPositionY = -60f;
            }
            else if ((align & (int)Yodo1U3dBannerAdPosition.BannerBottom) == (int)Yodo1U3dBannerAdPosition.BannerBottom)
            {
                anchorMinY = 0f;
                anchorMaxY = 0f;
                pivotY = 1f;
                anchoredPositionY = 120f;
            }
            else if ((align & (int)Yodo1U3dBannerAdPosition.BannerTop) == (int)Yodo1U3dBannerAdPosition.BannerTop)
            {
                anchorMinY = 1f;
                anchorMaxY = 1f;
                pivotY = 1f;
                anchoredPositionY = 0f;
            }
            BannerSampleAdEditor.GetComponent<RectTransform>().anchorMin = new Vector2(anchorMinX, anchorMinY);
            BannerSampleAdEditor.GetComponent<RectTransform>().anchorMax = new Vector2(anchorMaxX, anchorMaxY);
            BannerSampleAdEditor.GetComponent<RectTransform>().pivot = new Vector2(pivotX, pivotY);
            BannerSampleAdEditor.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionX, anchoredPositionY);
            if (!BannerSampleAdEditor.activeSelf)
            {
                Debug.Log(Yodo1U3dMas.TAG + "Editor Banner ad opened");
            }
            BannerSampleAdEditor.SetActive(true);
            
        }
    }
    public static void ShowBannerAdsInEditor(int align, int offsetX, int offsetY)
    {
        if (BannerSampleAdEditor != null)
        {
            anchorMinX = 0.5f;
            anchorMinY = 0.5f;
            anchorMaxX = 0.5f;
            anchorMaxY = 0.5f;
            pivotX = 0.5f;
            pivotY = 0f;
            anchoredPositionX = 0f;
            anchoredPositionY = -60f;
            if ((align & (int)Yodo1U3dBannerAdPosition.BannerHorizontalCenter) == (int)Yodo1U3dBannerAdPosition.BannerHorizontalCenter)
            {
                anchorMinX = 0.5f;
                anchorMaxX = 0.5f;
                pivotX = 0.5f;
                anchoredPositionX = 0f;

            }
            else if ((align & (int)Yodo1U3dBannerAdPosition.BannerRight) == (int)Yodo1U3dBannerAdPosition.BannerRight)
            {
                anchorMinX = 1f;
                anchorMaxX = 1f;
                pivotX = 0.5f;
                anchoredPositionX = -320f;
            }
            else if ((align & (int)Yodo1U3dBannerAdPosition.BannerLeft) == (int)Yodo1U3dBannerAdPosition.BannerLeft)
            {
                anchorMinX = 0f;
                anchorMaxX = 0f;
                pivotX = 0.5f;
                anchoredPositionX = 320f;
            }

            if ((align & (int)Yodo1U3dBannerAdPosition.BannerVerticalCenter) == (int)Yodo1U3dBannerAdPosition.BannerVerticalCenter)
            {
                anchorMinY = 0.5f;
                anchorMaxY = 0.5f;
                pivotY = 0f;
                anchoredPositionY = -60f;
            }
            else if ((align & (int)Yodo1U3dBannerAdPosition.BannerBottom) == (int)Yodo1U3dBannerAdPosition.BannerBottom)
            {
                anchorMinY = 0f;
                anchorMaxY = 0f;
                pivotY = 1f;
                anchoredPositionY = 120f;
            }
            else if ((align & (int)Yodo1U3dBannerAdPosition.BannerTop) == (int)Yodo1U3dBannerAdPosition.BannerTop)
            {
                anchorMinY = 1f;
                anchorMaxY = 1f;
                pivotY = 1f;
                anchoredPositionY = 0f;
            }
            BannerSampleAdEditor.GetComponent<RectTransform>().anchorMin = new Vector2(anchorMinX, anchorMinY);
            BannerSampleAdEditor.GetComponent<RectTransform>().anchorMax = new Vector2(anchorMaxX, anchorMaxY);
            BannerSampleAdEditor.GetComponent<RectTransform>().pivot = new Vector2(pivotX, pivotY);
            BannerSampleAdEditor.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionX, anchoredPositionY);
            BannerSampleAdEditor.SetActive(true);
            Debug.Log(Yodo1U3dMas.TAG + "Editor Banner ad opened");
        }
    }
    public static void ShowInterstitialAdsInEditor()
    {
        if (InterstitialSampleAdEditor != null)
        {
            DisableGUI = true;
            InterstitialSampleAdEditor.SetActive(true);
            Yodo1U3dMasCallback.ForwardEvent("onInterstitialAdOpenedEvent");
        }
    }
    public static void ShowRewardedVideodsInEditor()
    {
        if (RewardedVideoSampleAdEditor != null)
        {
            DisableGUI = true;
            RewardedVideoSampleAdEditor.SetActive(true);
            Yodo1U3dMasCallback.ForwardEvent("onRewardedAdOpenedEvent");
        }
    }
    public static void HideBannerAdsInEditor()
    {
        if (BannerSampleAdEditor != null)
        {
            if (BannerSampleAdEditor.activeSelf)
            {
                Debug.Log(Yodo1U3dMas.TAG + "Editor Banner ad closed");
            }
            BannerSampleAdEditor.SetActive(false);
            
        }
    }
    public static void DestroyBannerAdsInEditor()
    {
        if (BannerSampleAdEditor != null)
        {
            if (BannerSampleAdEditor.activeSelf)
            {
                Debug.Log(Yodo1U3dMas.TAG + "Editor Banner ad destroyed");
            }
            BannerSampleAdEditor.SetActive(false);
            
        }
    }
    public static void CloseInterstitialAdsInEditor()
    {
        if (InterstitialSampleAdEditor != null)
        {
            DisableGUI = false;
            InterstitialSampleAdEditor.SetActive(false);
            Yodo1U3dMasCallback.ForwardEvent("onInterstitialAdClosedEvent");
        }
    }
    public static void CloseRewardedVideodsInEditor()
    {
        if (RewardedVideoSampleAdEditor != null)
        {
            DisableGUI = false;
            RewardedVideoSampleAdEditor.SetActive(false);
            if (GrantReward)
            {
                Yodo1U3dMasCallback.ForwardEvent("onRewardedAdReceivedRewardEvent");
                GrantReward = false;
            }
            Yodo1U3dMasCallback.ForwardEvent("onRewardedAdClosedEvent");
        }
    }
    public static void GetRewardsInEditor()
    {
        GrantReward = true;
    }
}
