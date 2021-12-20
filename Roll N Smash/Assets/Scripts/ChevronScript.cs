using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChevronScript : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");    
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
        }
    }
}
