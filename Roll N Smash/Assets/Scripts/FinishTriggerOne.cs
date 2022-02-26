using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using Yodo1.MAS;

public class FinishTriggerOne : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public GameObject textHolder;
    public GameObject dancingPlayer;
    public LevelBarScript levelBar;
    public Transform playerTransfrom;

    //UI
    public GameObject nextLevel;
    public GameObject alpha;
    public GameObject greatText;
    public GameObject tempGems;
    public GameObject tempBodies;
    public AudioSource finishSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        deathHandler();
    }

    public void deathHandler()
    {
        if (player.GetComponent<PlayerMovement>().size <= 0)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, 0.015f);
            player.GetComponent<Transform>().localScale = Vector3.zero;
            Destroy(textHolder);

        }
    }

    IEnumerator StopAfterSec()
    {
        yield return new WaitForSeconds(2);
        rb.velocity = Vector3.zero;
        Destroy(player);
        Instantiate(dancingPlayer, playerTransfrom);
        nextLevel.SetActive(true);
        alpha.SetActive(true);
        greatText.SetActive(true);
        tempGems.SetActive(true);
        tempBodies.SetActive(true);
        finishSound.Play();
        if (GameManagerScript.vibrationEnabled == true)
        {
            Vibration.VibrateNope();
        }
    }

    IEnumerator AddGemsAndBodies()
    {
        yield return new WaitForSeconds(7.5f);
        int sum = (PlayerScript.bodyCount + PlayerScript.tempGemCount) + PlayerPrefs.GetInt("Gems");
        PlayerPrefs.SetInt("Gems", sum);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            player.GetComponent<PlayerDeath>().enabled = false;
            player.GetComponent<TrailRenderer>().enabled = false;
            levelBar.enabled = false;
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
            //TinySauce.OnGameFinished(true, PlayerScript.tempGemCount);
            StartCoroutine(StopAfterSec());
            StartCoroutine(AddGemsAndBodies());
            StartCoroutine(ShowAds());
        }
    }

    IEnumerator ShowAds()
    {
        yield return new WaitForSeconds(1.5f);
        if (Application.platform == RuntimePlatform.Android)
        {
            //Advertisement.Show("Interstitial_Android");
            if (Yodo1U3dMas.IsInterstitialAdLoaded()) Yodo1U3dMas.ShowInterstitialAd();
        }
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            //Advertisement.Show("Interstitial_iOS");
            if (Yodo1U3dMas.IsInterstitialAdLoaded()) Yodo1U3dMas.ShowInterstitialAd();
        }
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            //Advertisement.Show("Interstitial_Android");
            if (Yodo1U3dMas.IsInterstitialAdLoaded()) Yodo1U3dMas.ShowInterstitialAd();
        }
    }
}
