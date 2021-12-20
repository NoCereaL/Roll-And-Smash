using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    //Retry
    public GameObject retryButton;
    public GameObject retryAlpha;
    public GameObject unluckyText;

    //Settings
    public GameObject cogOff;
    public GameObject cogOn;
    public GameObject settings;
    public GameObject sound;
    public GameObject soundOff;
    public GameObject vibration;
    public GameObject vibrationOff;
    public Animation settingsAnim;
    public void retry()
    {
        retryButton.SetActive(false);
        retryAlpha.SetActive(false);
        unluckyText.SetActive(false);
        GameManagerScript.settingsOpen = false;
        PlayerScript.bodyCount = 0;
        PlayerScript.tempGemCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextLevel()
    {
        PlayerScript.bodyCount = 0;
        PlayerScript.tempGemCount = 0;
        GameManagerScript.settingsOpen = false;
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        SceneManager.LoadScene("LevelLoadingScene");
    }

    public void OpenSettings()
    {
        GameManagerScript.settingsOpen = true;
        settings.SetActive(true);
        settingsAnim.enabled = true;
        cogOn.SetActive(true);
        cogOff.SetActive(false);
        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            sound.SetActive(true);
            soundOff.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Sound") == 0)
        {
            soundOff.SetActive(true);
            sound.SetActive(false);
        }
        if(GameManagerScript.vibrationEnabled == true)
        {
            vibration.SetActive(true);
            vibrationOff.SetActive(false);
        }
        if(GameManagerScript.vibrationEnabled == false)
        {
            vibrationOff.SetActive(true);
            vibration.SetActive(false);
        }
    }

    public void CloseSettings()
    {
        GameManagerScript.settingsOpen = false;
        settings.SetActive(false);
        settingsAnim.enabled = false;
        cogOn.SetActive(false);
        cogOff.SetActive(true);
    }

    public void VibrationOn()
    {
        PlayerPrefs.SetInt("Vibration", 1);
        vibrationOff.SetActive(false);
        vibration.SetActive(true);
    }

    public void VibrationOff()
    {
        PlayerPrefs.SetInt("Vibration", 0);
        vibration.SetActive(false);
        vibrationOff.SetActive(true);
    }

    public void SoundOn()
    {
        PlayerPrefs.SetInt("Sound", 1);
        soundOff.SetActive(false);
        sound.SetActive(true);
    }

    public void SoundOff()
    {
        PlayerPrefs.SetInt("Sound", 0);
        sound.SetActive(false);
        soundOff.SetActive(true);
    }

    public void HapticDown()
    {
        if(GameManagerScript.vibrationEnabled == true)
        {
            Vibration.VibratePop();
        }
    }

    public void HapticUp()
    {
        if (GameManagerScript.vibrationEnabled == true)
        {
            Vibration.VibratePeek();
        }
    }
}
