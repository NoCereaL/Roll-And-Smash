using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Rigidbody[] rigidbodies;
    [SerializeField] Rigidbody rigidbody;
    public float throwForce;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        enemy = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyIsDead();
    }

    public void CheckEnemyIsDead()
    {
        if(enemy.GetComponent<EnemyScript>().dead == true)
        {
            rigidbody.isKinematic = false;
            enemy.GetComponent<Animator>().enabled = false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            enemy.GetComponent<EnemyScript>().dead = true;

            enemy.GetComponent<Animator>().enabled = false;

            //rigidbody.AddForce(new Vector3(0,0,400), ForceMode.Impulse);

            
        }
    }
}
