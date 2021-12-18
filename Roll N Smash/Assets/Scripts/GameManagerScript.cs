using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public bool playing;
    public static bool vibrationEnabled;
    public GameObject tutorial;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (!PlayerPrefs.HasKey("Vibration"))
        {
            vibrationEnabled = true;
        }
        if (!PlayerPrefs.HasKey("Sound"))
        {
            AudioListener.volume = 1;
        }
        Vibration.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount >= 1)
        {
            playing = true;
            tutorial.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
        }
        ForTesting();
        VibrationStatus();
        SoundStatus();
    }

    public void VibrationStatus()
    {
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
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
