using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RewardedVideoSampleAds : MonoBehaviour
{
    public Text RewardLabel;
    public Text RewardTimer;
    private int TimeRemaining = 5;
    public RectTransform LogoRectTransform;
    private void OnEnable()
    {
        StartCoroutine(StartTimerForReward());
        if (Screen.height > Screen.width)
        {
            LogoRectTransform.anchorMin = new Vector2(0f, 0.5f);
            LogoRectTransform.anchorMax = new Vector2(1, 0.5f);
            LogoRectTransform.pivot = new Vector2(0.5f, 0.5f);
            LogoRectTransform.localScale = new Vector3(1, ((float)Screen.height / (float)Screen.width), 1);
            LogoRectTransform.offsetMin = Vector2.zero;
            LogoRectTransform.offsetMax = new Vector2(0, 417);
            LogoRectTransform.localPosition = Vector3.zero;
        }
    }
    private IEnumerator StartTimerForReward()
    {
        RewardTimer.gameObject.SetActive(true);
        RewardTimer.text = TimeRemaining + " seconds remaining";
        yield return new WaitForSecondsRealtime(1.0f);
        TimeRemaining--;
        
        if (TimeRemaining == 0)
        {
            RewardTimer.gameObject.SetActive(false);
            TimeRemaining = 5;
            RewardLabel.text = "RV shown successfully, and reward granted. Reward callback will send on ad close.";
            Yodo1EditorAds.GetRewardsInEditor();
        }
        else
        {
            StartCoroutine(StartTimerForReward());
        }
    }
    public void CloseRewardedVideoAds()
    {
        StopAllCoroutines();
        Yodo1EditorAds.CloseRewardedVideodsInEditor();
        RewardLabel.text = "Reward not yet granted.";
        TimeRemaining = 5;
    }
}
