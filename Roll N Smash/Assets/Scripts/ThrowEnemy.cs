using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEnemy : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody rb;
    private GameObject player;
    public float throwForce;
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject;
        rb = this.gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy)
        {
            Debug.Log("Hit Reg");
            rb.AddForce(new Vector3(throwForce, throwForce, throwForce));
            rb.velocity = new Vector3(0f, 0f, throwForce);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("Hit Reg");
            player = collider.gameObject;
            rb.AddForce(new Vector3(throwForce,throwForce,throwForce));
            rb.velocity = new Vector3(0f,0f,throwForce);
        }
    }
}
