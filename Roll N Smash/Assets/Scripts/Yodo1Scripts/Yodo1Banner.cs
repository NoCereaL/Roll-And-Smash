using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;

public class Yodo1Banner : MonoBehaviour
{
    private Yodo1U3dBannerAdView bannerAdView;

    public void Start()
    {
        // Initialize the MAS SDK.
        Yodo1U3dMas.SetInitializeDelegate((bool success, Yodo1U3dAdError error) => { });
        //Yodo1U3dMas.InitializeSdk();

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        // Clean up banner before reusing
        if (bannerAdView != null)
        {
            bannerAdView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerAdView = new Yodo1U3dBannerAdView(Yodo1U3dBannerAdSize.Banner, Yodo1U3dBannerAdPosition.BannerTop | Yodo1U3dBannerAdPosition.BannerHorizontalCenter);

        // Load banner ads, the banner ad will be displayed automatically after loaded
        bannerAdView.LoadAd();
        DontDestroyOnLoad(this.gameObject);
    }
}
