using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParts : MonoBehaviour
{
    [SerializeField] GameObject enemy;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            enemy.GetComponent<EnemyScript>().dead = true;
            enemy.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
