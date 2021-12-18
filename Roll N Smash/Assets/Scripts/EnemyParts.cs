using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParts : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private GameObject player;
    private AudioSource deathSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        deathSound = enemy.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && enemy.GetComponent<EnemyScript>().dead == false && enemy.GetComponentInChildren<SkinnedMeshRenderer>().material.color != player.GetComponent<MeshRenderer>().material.color)
        {
            player.GetComponent<PlayerMovement>().size -= enemy.GetComponent<EnemyScript>().size;
            CameraScript.cameraPos.x = CameraScript.cameraPos.x - enemy.GetComponent<EnemyScript>().size;
            CameraScript.cameraPos.y = CameraScript.cameraPos.y + enemy.GetComponent<EnemyScript>().size;
        }

        if (collision.collider.tag == "Player")
        {
            if (enemy.GetComponent<EnemyScript>().dead == false)
            {
                deathSound.Play();
                PlayerScript.bodyCount++;
                if (GameManagerScript.vibrationEnabled == true)
                {
                    Vibration.VibratePop();
                }
            }
            enemy.GetComponent<EnemyScript>().dead = true;
            enemy.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
