using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempGemCount : MonoBehaviour
{
    public Text gemText;
    // Update is called once per frame
    void Update()
    {
        gemText.text = "+"+PlayerScript.tempGemCount;
    }
}
