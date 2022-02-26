using UnityEngine;
using Yodo1.MAS;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class YodoAdsManager : MonoBehaviour
{
    public static YodoAdsManager instance;

    [Space(10)]
    [Header("Privacy Popup Settings")]
    [SerializeField]
    private bool privacyPopup = true;
    [Header("Custom Privacy links (optional) ")]
    [Tooltip("Enter your privacy policy link. Leave empty if you do not have a privacy policy")]
    [SerializeField]
    string privacyPolicyLink;
    [Tooltip("Enter your terms of services link. Leave empty if you do not have a terms of services.")]
    [SerializeField]
    string termOfServiceLink;

    //[Header("Pause game when the interstitial or reward ads are playing(optionl)")]
    //[SerializeField]
    //private bool autoPauseGame = false;

    [Space(10)]
    [Header("MAS SDK Initialization Events")]
    [SerializeField] UnityEvent OnSDKIntialized;
    [SerializeField] UnityEvent OnSDKInitializationFailed;

    bool isInitialized = false;


    private void Awake()
    {
        if (FindObjectsOfType<YodoAdsManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
#if UNITY_EDITOR
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
#endif
    private void Start()
    {
        Yodo1U3dMasCallback.OnSdkInitializedEvent += (success, error) =>
        {

            Debug.Log(Yodo1U3dMas.TAG + "NoCode OnSdkInitializedEvent, success:" + success + ", error: " + error.ToString());
            if (success)
            {
                Debug.Log(Yodo1U3dMas.TAG + "NoCode The initialization has succeeded");
                OnSDKIntialized.Invoke();
                isInitialized = true;

            }
            else
            {
                OnSDKInitializationFailed.Invoke();
                Debug.Log(Yodo1U3dMas.TAG + "NoCode The initialization has failed");
            }
        };

        if (privacyPopup)
        {
            if (!string.IsNullOrEmpty(privacyPolicyLink) && !string.IsNullOrEmpty(termOfServiceLink))
            {
                Yodo1AdBuildConfig config = new Yodo1AdBuildConfig()
                    .enableUserPrivacyDialog(true);
                Yodo1U3dMas.SetAdBuildConfig(config);
            }
            else if (!string.IsNullOrEmpty(privacyPolicyLink) && !string.IsNullOrEmpty(termOfServiceLink))
            {
                Yodo1AdBuildConfig config = new Yodo1AdBuildConfig()
                    .enableUserPrivacyDialog(true)
                    .privacyPolicyUrl(privacyPolicyLink);
                Yodo1U3dMas.SetAdBuildConfig(config);
            }
            else if (!string.IsNullOrEmpty(privacyPolicyLink) && !string.IsNullOrEmpty(termOfServiceLink))
            {
                Yodo1AdBuildConfig config = new Yodo1AdBuildConfig()
                    .enableUserPrivacyDialog(true)
                    .userAgreementUrl(termOfServiceLink);
                Yodo1U3dMas.SetAdBuildConfig(config);
            }
            else
            {
                Yodo1AdBuildConfig config = new Yodo1AdBuildConfig()
                    .enableUserPrivacyDialog(true)
                    .privacyPolicyUrl(privacyPolicyLink)
                    .userAgreementUrl(termOfServiceLink);
                Yodo1U3dMas.SetAdBuildConfig(config);
            }
        }

        if (!isInitialized)
        {
            Yodo1U3dMas.InitializeSdk();
            //Yodo1U3dMas.SetAutoPauseGame(autoPauseGame);
        }
    }
#if UNITY_EDITOR
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EventSystem sceneEventSystem = FindObjectOfType<EventSystem>();
        if (sceneEventSystem == null)
        {
            Yodo1EditorAds.AdHolder = Instantiate(Resources.Load("SampleAds/AdHolder") as GameObject);
        }
        if (Yodo1EditorAds.BannerSampleAdEditor == null)
        {
            Yodo1EditorAds.BannerSampleAdEditor = Instantiate(Resources.Load("SampleAds/BannerSampleAdPanel") as GameObject, GameObject.Find("Canvas").transform);
        }
        if (isInitialized)
        {
            if (Yodo1EditorAds.tempAlign != 0)
            {
                Yodo1EditorAds.ShowBannerAdsInEditor(Yodo1EditorAds.tempAlign);
            }
        }
        Yodo1EditorAds.InitializeAds();
    }
#endif
}
