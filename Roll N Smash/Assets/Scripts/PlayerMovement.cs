using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    public float size;
    private float defaultSpeed;
    [SerializeField] GameObject particleController;
    private GameObject player;
    private Rigidbody rb;
    public int randNum;
    [SerializeField] Material particleColor;
    public bool dead;
    public AudioSource increaseSound;
    public AudioSource decreaseSound;

    [SerializeField] Vector3 pos;
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
        player.transform.localScale = new Vector3(size, size, size);
        AutoMove();
        Move();
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
        //GameObject PickUp = collision.collider.gameObject;
        /*if(collision.collider.tag == "enemy" && PickUp.GetComponent<EnemyScript>().dead == false)
        {
            size -= 1;
            player.transform.localScale = new Vector3(size,size,size);
            PickUp.GetComponent<EnemyScript>().dead = true;

            cam.fieldOfView++;
            CameraScript.cameraPos.x--;
            CameraScript.cameraPos.y++;
        }*/
        //cam.fieldOfView++;
        //maxSpeed += 100;
        //rb.AddForce(new Vector3(0, 0, 50), ForceMode.Impulse);

        //StartCoroutine(thrustForward());
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject PickUp = collider.gameObject;
        if (collider.tag == "pickup")
        {
            //Increase Size on Trigger Enter
            size += 0.5f;
            player.transform.localScale = new Vector3(size, size, size);
            particleController.transform.position = PickUp.transform.position;
            particleController.GetComponent<ParticleSystem>().Play();
            particleController.GetComponent<ParticleSystem>().startColor = PickUp.GetComponent<MeshRenderer>().material.color;
            particleColor.color = PickUp.GetComponent<MeshRenderer>().material.color;
            Destroy(PickUp);

            //Change the Player Color Depending on Orb Color
            player.GetComponent<MeshRenderer>().material.color = PickUp.GetComponent<MeshRenderer>().material.color;

            CameraScript.cameraPos.x = CameraScript.cameraPos.x + 0.5f;         //x is changing y-axis of camera  
            CameraScript.cameraPos.y = CameraScript.cameraPos.y - 0.5f;         //y is changing z-axis of camera

            //CameraScript.cameraPos.x++;         //x is changing y-axis of camera  
            //CameraScript.cameraPos.y--;         //y is changing z-axis of camera

            increaseSound.Play();
        }
    }

    IEnumerator thrustForward()
    {
        maxSpeed = 100;
        rb.AddForce(new Vector3(0, 0, 50), ForceMode.Impulse);
        yield return new WaitForSeconds(0.1f);
        maxSpeed = defaultSpeed;
    }
    //Create a trigger on/infront of enemies to increase player speed using a courotine when trigger enter to increase speed when barging
}
