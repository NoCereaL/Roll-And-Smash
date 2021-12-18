using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyCountValue : MonoBehaviour
{
    public Text countText;
    public Text countTextTwo;

    // Update is called once per frame
    void Update()
    {
        countText.text = PlayerScript.bodyCount + "";
        countTextTwo.text = PlayerScript.bodyCount + "";
    }
}
