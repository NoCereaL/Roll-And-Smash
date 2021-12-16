using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTriggerOne : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public GameObject textHolder;
    public GameObject dancingPlayer;
    public LevelBarScript levelBar;
    public Transform playerTransfrom;

    //UI
    public GameObject nextLevel;
    public GameObject alpha;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        deathHandler();
    }

    public void deathHandler()
    {
        if (player.GetComponent<PlayerMovement>().size <= 0)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, 0.015f);
            player.GetComponent<Transform>().localScale = Vector3.zero;
            Destroy(textHolder);

        }
    }

    IEnumerator StopAfterSec()
    {
        yield return new WaitForSeconds(2);
        rb.velocity = Vector3.zero;
        Destroy(player);
        Instantiate(dancingPlayer, playerTransfrom);
        nextLevel.SetActive(true);
        alpha.SetActive(true);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            player.GetComponent<PlayerDeath>().enabled = false;
            levelBar.enabled = false;
            StartCoroutine(StopAfterSec());
        }
    }
}
