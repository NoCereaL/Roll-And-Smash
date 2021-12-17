using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private GameObject player;
    public Vector3 pos;

    void Start()
    {
        player = this.gameObject;
    }

    void Update()
    {
        TouchMove();
    }
    public void TouchMove()
    {
        if (Input.touchCount >= 1)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, player.transform.position.z));
            float distance;
            xy.Raycast(ray, out distance);
            pos = ray.GetPoint(distance);
            //pos = cam.ScreenToWorldPoint(touch.position);
            transform.position = new Vector3(pos.x, player.transform.position.y, player.transform.position.z);
        }
    }
}
