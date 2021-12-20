using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float speed;
    public float maxSpeed;
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

    //Trail
    private TrailRenderer trail;
    public Material trailMat;

    [SerializeField] Vector3 pos;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        rb = this.gameObject.GetComponent<Rigidbody>();
        trail = this.gameObject.GetComponent<TrailRenderer>();
        Color32[] color = {Color.red, Color.green, Color.blue };
        randNum = Random.Range(0, 3);
        player.GetComponent<MeshRenderer>().material.color = color[randNum];
        defaultSpeed = maxSpeed;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.localScale = new Vector3(size, size, size);
        trail.startWidth = size - 0.5f;
        trail.time = (size*2) / 10f;
        trailMat.color = player.GetComponent<MeshRenderer>().material.color;
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
        //rb.AddForce(new Vector3(0,0,speed));
        if (rb.velocity.z >= maxSpeed)
        {
            rb.velocity = new Vector3(0, 0, maxSpeed);
        }
        rb.velocity = new Vector3(0, 0, maxSpeed);
        //rb.AddForce(new Vector3(0,-50,0), ForceMode.Force);
        rb.AddForce(new Vector3(0,-30f,0), ForceMode.Acceleration);     //Adds Gravity to the player so it falls back down to the ground
    }

    public void AirTimeCheck()
    {
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

}
