using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class PlayerDeath : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public GameObject textHolder;
    public GameObject retryButton;
    public GameObject retryAlpha;
    public GameObject unluckyText;

    public AudioSource deathSound;

    private int adChance;
    private int showAdsAfter;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        rb = player.GetComponent<Rigidbody>();
        showAdsAfter = 1;
        adChance = Random.Range(0, 2);
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
            player.GetComponent<PlayerMovement>().dead = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<TrailRenderer>().enabled = false;
            player.GetComponent<SphereCollider>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, 0.15f);
            player.GetComponent<Transform>().localScale = Vector3.zero;
            Destroy(textHolder);
            retryButton.SetActive(true);
            retryAlpha.SetActive(true);
            unluckyText.SetActive(true);
            //StartCoroutine(StopAfterSec());
        }
    }

    IEnumerator StopAfterSec()
    {
        yield return new WaitForSeconds(5);
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (player.GetComponent<PlayerMovement>().size <= 0)
        {
            deathSound.Play();
            ShowAdsAfterDeath();
            //TinySauce.OnGameFinished(false, PlayerScript.tempGemCount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<PlayerMovement>().size <= 0)
        {
            deathSound.Play();
        }
    }

    public void ShowAdsAfterDeath()
    {
        if(adChance == showAdsAfter)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                Advertisement.Show("Interstitial_Android");
            }
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                Advertisement.Show("Interstitial_iOS");
            }
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                Advertisement.Show("Interstitial_Android");
            }
        }
    }
}
