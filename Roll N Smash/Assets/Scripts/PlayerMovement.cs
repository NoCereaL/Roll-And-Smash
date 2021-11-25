using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float size;
    private float defaultSpeed;
    [SerializeField] GameObject particleController;
    private GameObject player;
    private Rigidbody rb;
    public int randNum;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        rb = this.gameObject.GetComponent<Rigidbody>();
        Color32[] color = {Color.red, Color.green, Color.blue };
        randNum = Random.Range(0, 3);
        player.GetComponent<MeshRenderer>().material.color = color[randNum];
        defaultSpeed = maxSpeed;
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

        //maxSpeed += 100;
        //rb.AddForce(new Vector3(0, 0, 50), ForceMode.Impulse);

        StartCoroutine(thrustForward());
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject PickUp = collider.gameObject;
        if (collider.tag == "pickup")
        {

            //Increase Size on Trigger Enter
            size += 1;
            player.transform.localScale = new Vector3(size, size, size);
            particleController.transform.position = PickUp.transform.position;
            particleController.GetComponent<ParticleSystem>().Play();
            particleController.GetComponent<ParticleSystem>().startColor = PickUp.GetComponent<MeshRenderer>().material.color;
            Destroy(PickUp);

            //Change the Player Color Depending on Orb Color
            player.GetComponent<MeshRenderer>().material.color = PickUp.GetComponent<MeshRenderer>().material.color;

            CameraScript.cameraPos.x++;
            CameraScript.cameraPos.y--;
        }
    }

    IEnumerator thrustForward()
    {
        maxSpeed += 100;
        rb.AddForce(new Vector3(0, 0, 50), ForceMode.Impulse);
        yield return new WaitForSeconds(0.1f);
        maxSpeed = defaultSpeed;
    }
}
