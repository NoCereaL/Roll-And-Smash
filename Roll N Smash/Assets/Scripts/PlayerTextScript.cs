using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextScript : MonoBehaviour
{
    private GameObject player;
    private GameObject textHolder;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        textHolder = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        textHolder.transform.position = player.transform.position;
        textHolder.transform.localScale = player.transform.localScale;
    }
}
