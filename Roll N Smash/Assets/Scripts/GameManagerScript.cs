using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public bool playing;
    public GameObject tutorial;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
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
