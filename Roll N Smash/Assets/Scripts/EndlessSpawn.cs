using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawn : MonoBehaviour
{
    [SerializeField] GameObject endlessObject;
    [SerializeField] Transform player;
    [SerializeField] Transform renderPoint;
    [SerializeField] Transform spawnPosition;

    [SerializeField] Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        endlessObject = this.gameObject;
        spawnPoint = spawnPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        if(player.position.z > renderPoint.position.z)
        {
            GameObject newObject = Instantiate(endlessObject, spawnPoint, Quaternion.identity, endlessObject.transform);
            newObject.transform.localScale = new Vector3(1, 1, 1);
            this.gameObject.GetComponent<EndlessSpawn>().enabled = false;
        }
    }
}
