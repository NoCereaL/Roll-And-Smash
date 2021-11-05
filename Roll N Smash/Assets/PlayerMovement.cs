using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float size;
    [SerializeField] GameObject particleController;
    private GameObject player;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        AutoMove();
    }

    public void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += movement * speed * Time.deltaTime;
    }

    public void AutoMove()
    {
        rb.AddForce(new Vector3(0,0,speed));
        if (rb.velocity.z >= maxSpeed)
        {
            rb.velocity = new Vector3(0, 0, maxSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject PickUp = collision.collider.gameObject;
        if(collision.collider.tag == "enemy" && PickUp.GetComponent<EnemyScript>().dead == false)
        {
            size -= 1;
            player.transform.localScale = new Vector3(size,size,size);
            PickUp.GetComponent<EnemyScript>().dead = true;

            CameraScript.cameraPos.x--;
            CameraScript.cameraPos.y++;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject PickUp = collider.gameObject;
        if (collider.tag == "pickup")
        {
            size += 1;
            player.transform.localScale = new Vector3(size, size, size);
            particleController.transform.position = PickUp.transform.position;
            particleController.GetComponent<ParticleSystem>().Play();
            particleController.GetComponent<ParticleSystem>().startColor = PickUp.GetComponent<MeshRenderer>().material.color;
            Destroy(PickUp);

            CameraScript.cameraPos.x++;
            CameraScript.cameraPos.y--;
        }
    }
}
