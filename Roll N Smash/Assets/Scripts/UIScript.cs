using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject retryButton;
    public GameObject retryAlpha;
    public void retry()
    {
        retryButton.SetActive(false);
        retryAlpha.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextLevel()
    {
        PlayerScript.bodyCount = 0;
        PlayerScript.tempGemCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
