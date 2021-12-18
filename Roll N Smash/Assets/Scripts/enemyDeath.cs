using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{

    [SerializeField] GameObject player;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            enemy.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
