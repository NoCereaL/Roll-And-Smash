using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChevronScript : MonoBehaviour
{
    private GameObject player;
    private AudioSource speedSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        speedSound = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider colliider)
    {
        if(colliider.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().maxSpeed += 5;
            speedSound.Play();
        }
    }
}
