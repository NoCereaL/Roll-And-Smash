using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Rigidbody[] rigidbodies;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            for (int i = 0; i >= rigidbodies.Length; i--)
            {
                rigidbodies[i].isKinematic = false;
            }
            enemy.GetComponent<Animator>().enabled = false;
        }
    }
}
