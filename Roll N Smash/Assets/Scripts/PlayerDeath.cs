using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public GameObject textHolder;
    public GameObject retryButton;
    public GameObject retryAlpha;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
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
            retryButton.SetActive(true);
            retryAlpha.SetActive(true);
            StartCoroutine(StopAfterSec());
        }
    }

    IEnumerator StopAfterSec()
    {
        yield return new WaitForSeconds(5);
        rb.velocity = Vector3.zero;
    }
}
