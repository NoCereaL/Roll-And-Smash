using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemScript : MonoBehaviour
{

    public Text gemText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gemText.text = PlayerPrefs.GetInt("Gems") +"";
    }
}
