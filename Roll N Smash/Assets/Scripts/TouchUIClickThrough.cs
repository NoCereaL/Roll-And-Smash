using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchUIClickThrough : MonoBehaviour
{
    private GameObject player;
    public GameObject tutorial;
    public GameObject settingsCog;
    public GameObject settingsCogOff;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

   public void StartGame()
    {
        GameManagerScript.playing = true;
        tutorial.SetActive(false);
        settingsCog.SetActive(false);
        settingsCogOff.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<TouchControls>().enabled = true;
    }
}
