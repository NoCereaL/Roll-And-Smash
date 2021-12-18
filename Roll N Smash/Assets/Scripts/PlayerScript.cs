using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public TextMeshPro textMesh;
    private PlayerMovement player;
    public static int bodyCount;
    public static int tempGemCount;
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
            PlayerPrefs.SetInt("Gems", GetGems()+collider.gameObject.GetComponent<GemValue>().gemValue);
            PlayerScript.tempGemCount++;
            Destroy(collider.gameObject);
            GameObject gem = Instantiate(uiGems, ui);
            gem.SetActive(true);
            gem.transform.position = new Vector3(player.transform.position.x, gem.transform.position.y, gem.transform.position.z);
            collectSound.Play();
        }
    }
}
