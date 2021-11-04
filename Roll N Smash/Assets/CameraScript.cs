using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraHolder.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z - 10);
        cameraHolder.transform.rotation = Quaternion.Euler(30,0,0);
    }
}
