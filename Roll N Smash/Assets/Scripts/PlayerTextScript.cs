using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTextScript : MonoBehaviour
{
    private GameObject player;
    private GameObject textHolder;
    public TextMeshPro textMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player_skin");
        textHolder = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        textHolder.transform.position = player.transform.position;
        textHolder.transform.localScale = player.transform.localScale;
        textMesh.color = player.GetComponent<MeshRenderer>().material.color;
    }
}
