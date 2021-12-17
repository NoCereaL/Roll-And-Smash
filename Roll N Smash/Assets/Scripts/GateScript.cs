using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GateScript : MonoBehaviour
{
    public float size;
    public bool mg;
    public bool g;
    public bool kg;
    public bool passed;
    private GameObject player;
    [SerializeField] TextMeshPro textMesh;

    //Audio
    public AudioSource increaseSound;
    public AudioSource decreaseSound;
    
    // Start is called before the first frame update
    void Start()
    {
        passed = false;
        player = GameObject.Find("Player");

        if (size > 0)
        {
            if (mg == true)
            {
                textMesh.text = "+" + size + "mg";
                size = size / 1000000;
            }
            if (g == true)
            {
                textMesh.text = "+" + size + "g";
                size = size / 1000;
            }
            if (kg == true)
            {
                textMesh.text = "+" + size + "kg";
            }
        }
        else
        {
            if (mg == true)
            {
                textMesh.text = size + "mg";
                size = size / 1000000;
            }
            if (g == true)
            {
                textMesh.text = size + "g";
                size = size / 1000;
            }
            if (kg == true)
            {
                textMesh.text = size + "kg";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && passed == false)
        {
            if (size > 0)
            {
                passed = true;
                player.GetComponent<PlayerMovement>().size += size;
                if (mg == true)
                {
                    CameraScript.cameraPos.x = CameraScript.cameraPos.x + (size / 1000000);
                    CameraScript.cameraPos.y = CameraScript.cameraPos.y - (size / 1000000);
                    increaseSound.Play();
                }
                else if (g == true)
                {
                    CameraScript.cameraPos.x = CameraScript.cameraPos.x + (size / 1000);
                    CameraScript.cameraPos.y = CameraScript.cameraPos.y - (size / 1000);
                    increaseSound.Play();
                }
                else
                {
                    CameraScript.cameraPos.x = CameraScript.cameraPos.x + size;
                    CameraScript.cameraPos.y = CameraScript.cameraPos.y - size;
                    increaseSound.Play();
                }
            }
            if(size < 0)
            {
                passed = true;
                player.GetComponent<PlayerMovement>().size += size;
                if (mg == true)
                {
                    CameraScript.cameraPos.x = CameraScript.cameraPos.x - (size / 1000000);
                    CameraScript.cameraPos.y = CameraScript.cameraPos.y + (size / 1000000);
                    decreaseSound.Play();
                }
                else if (g == true)
                {
                    CameraScript.cameraPos.x = CameraScript.cameraPos.x - (size / 1000);
                    CameraScript.cameraPos.y = CameraScript.cameraPos.y + (size / 1000);
                    decreaseSound.Play();
                }
                else
                {
                    CameraScript.cameraPos.x = CameraScript.cameraPos.x - size;
                    CameraScript.cameraPos.y = CameraScript.cameraPos.y + size;
                    decreaseSound.Play();
                }
            }
        }
    }
}
