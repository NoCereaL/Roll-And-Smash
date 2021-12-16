using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public TextMeshPro textMesh;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = player.size + "kg";
    }
}
