using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public TextMeshPro textMesh;
    private PlayerMovement player;
    public AudioSource collectSound;
    public GameObject uiGems;
    public Transform ui;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = player.size + "kg";
    }

    public int GetGems()
    {
        return PlayerPrefs.GetInt("Gems");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "gem")
        {
            PlayerPrefs.SetInt("Gems", GetGems()+5);
            Destroy(collider.gameObject);
            GameObject gem = Instantiate(uiGems, ui);
            gem.SetActive(true);
            collectSound.Play();
        }
    }
}
