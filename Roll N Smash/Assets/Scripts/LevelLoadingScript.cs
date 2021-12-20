using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoadingScript : MonoBehaviour
{
    public Slider loadingBar;
    public Text barValue;

    private void Start()
    {
        LevelLoader();
    }
    private void Update()
    {
        //LevelLoader();
    }
    public void LevelLoader()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            StartCoroutine(LoadAsync(1));
        }
        else
        {
            StartCoroutine(LoadAsync(PlayerPrefs.GetInt("Level")));
        }
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            loadingBar.value = progress;
            barValue.text = (progress * 100f) + "%";
            yield return null;
        }

    }
}
