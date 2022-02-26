using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Advertisements;

public class AdBanner : MonoBehaviour
{
    [SerializeField] string androidPlacementId;
    [SerializeField] string iOSPlacementId;
    private string _placementId;
    // Start is called before the first frame update
    void Start()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            _placementId = androidPlacementId;
        }
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _placementId = iOSPlacementId;
        }
        else
        {
            _placementId = androidPlacementId;
        }
        StartCoroutine(ShowBanner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowBanner()
    {
        yield return new WaitForSeconds(1);
        //Advertisement.Banner.Show(_placementId);
        //Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }
}
