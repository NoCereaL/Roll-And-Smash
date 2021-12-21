using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGameScript : MonoBehaviour
{
    public void PlayAgain()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("LevelLoadingScene");
    }
}
