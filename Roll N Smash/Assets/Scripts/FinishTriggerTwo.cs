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
        finishSound.Play();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            deathHandler();
        }
    }
}