using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public bool dead;
    public float size;
    public GameObject enemyMesh;
    public Color32 color;
    public TextMeshPro textMesh;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        enemyMesh.GetComponent<SkinnedMeshRenderer>().material.color = color;
        textMesh.text = size + "kg";
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            enemyMesh.GetComponent<SkinnedMeshRenderer>().material.color = Color.gray;
        }
    }
}
