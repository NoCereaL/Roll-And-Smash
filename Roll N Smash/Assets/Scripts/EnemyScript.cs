using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool dead;
    public GameObject enemyMesh;
    public Color32 color;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        enemyMesh.GetComponent<SkinnedMeshRenderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
