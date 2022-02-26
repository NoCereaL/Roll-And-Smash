using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
//using GameAnalyticsSDK;

public class GameManagerScript : MonoBehaviour
{
    public static bool playing;
    public static bool settingsOpen;
    public static bool vibrationEnabled;
    public GameObject tutorial;
    public GameObject settingsCog;
    public GameObject settingsCogOff;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Vibration.Init();
        //GameAnalytics.Initialize();
        //TinySauce.OnGameStarted(levelNumber: PlayerPrefs.GetInt("Level")+"");
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Application.targetFrameRate = 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount >= 1 && settingsOpen == false && !IsTouchOverUI() && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            playing = true;
            tutorial.SetActive(false);
            settingsCog.SetActive(false);
            settingsCogOff.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<TouchControls>().enabled = true;
        }
        ForTesting();
        VibrationStatus();
        SoundStatus();
    }

    public void CheckDefault()
    {
        if (!PlayerPrefs.HasKey("Vibration"))
        {
            vibrationEnabled = true;
        }
        if (!PlayerPrefs.HasKey("Sound"))
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("Sound", 1);
        }
    }

    public void VibrationStatus()
    {
        CheckDefault();
        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibrationEnabled = true;
        }
        if (PlayerPrefs.GetInt("Vibration") == 0)
        {
            vibrationEnabled = false;
        }
    }

    public void SoundStatus()
    {
        CheckDefault();
        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.volume = 1;
        }
        if(PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.volume = 0;
        }
    }

    public void ForTesting()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playing = true;
            tutorial.SetActive(false);
            settingsCog.SetActive(false);
            settingsCogOff.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    public bool IsTouchOverUI()
    {
        Touch touch = Input.GetTouch(0);
        int id = touch.fingerId;
        return EventSystem.current.IsPointerOverGameObject(id);
    }
}
