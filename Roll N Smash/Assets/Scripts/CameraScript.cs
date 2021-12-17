using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    [SerializeField] GameObject player;
    public static Vector2 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = new Vector2(7f, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        cameraHolder.transform.position = new Vector3(0, player.transform.position.y + cameraPos.x, player.transform.position.z + cameraPos.y);
        //cameraHolder.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + cameraPos.x, player.transform.position.z + cameraPos.y);
        cameraHolder.transform.rotation = Quaternion.Euler(30,0,0);
    }
}
