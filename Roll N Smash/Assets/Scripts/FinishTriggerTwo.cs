using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTriggerTwo : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public GameObject textHolder;
    public GameObject dancingPlayer;
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

    }

    public void deathHandler()
    {
        Destroy(player);
        Destroy(textHolder);
        Instantiate(dancingPlayer, playerTransfrom);
        nextLevel.SetActive(true);
        alpha.SetActive(true);
        greatText.SetActive(true);
        tempGems.SetActive(true);
        tempBodies.SetActive(true);
        finishSound.Play();
        if(GameManagerScript.vibrationEnabled == true)
        {
            Vibration.VibrateNope();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            deathHandler();
        }
    }
}
