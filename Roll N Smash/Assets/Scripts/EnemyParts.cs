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
        if (collision.collider.tag == "Player" && enemy.GetComponent<EnemyScript>().dead == false && enemy.GetComponentInChildren<SkinnedMeshRenderer>().material.color != player.GetComponent<MeshRenderer>().material.color)
        {
            player.GetComponent<PlayerMovement>().size -= 0.5f;
            CameraScript.cameraPos.x--;
            CameraScript.cameraPos.y++;
        }

        if (collision.collider.tag == "Player")
        {
            enemy.GetComponent<EnemyScript>().dead = true;
            enemy.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
