using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;

public class Yodo1AdsInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Yodo1U3dMas.SetCCPA(true);
        Yodo1U3dMas.SetCOPPA(true);
        Yodo1U3dMas.SetGDPR(true);
        Yodo1U3dMas.InitializeSdk();
        InitializeInterstitialAds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeInterstitialAds()
    {
        Yodo1U3dMasCallback.Interstitial.OnAdOpenedEvent +=
        OnInterstitialAdOpenedEvent;
        Yodo1U3dMasCallback.Interstitial.OnAdClosedEvent +=
        OnInterstitialAdClosedEvent;
        Yodo1U3dMasCallback.Interstitial.OnAdErrorEvent +=
        OnInterstitialAdErorEvent;
    }

    private void OnInterstitialAdOpenedEvent()
    {
        Debug.Log("[Yodo1 Mas] Interstitial ad opened");
    }

    private void OnInterstitialAdClosedEvent()
    {
        Debug.Log("[Yodo1 Mas] Interstitial ad closed");
    }

    private void OnInterstitialAdErorEvent(Yodo1U3dAdError adError)
    {
        Debug.Log("[Yodo1 Mas] Interstitial ad error - " + adError.ToString());
    }
}
