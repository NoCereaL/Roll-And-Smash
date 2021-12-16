using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarScript : MonoBehaviour
{
    private Transform startPoint;
    private Transform finishPoint;
    private Transform player;

    public Text currentLevelText;
    public Text nextLevelText;
    public Slider levelBar;

    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = GameObject.Find("Start").GetComponent<Transform>();
        finishPoint = GameObject.Find("Finish").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = GetDistance();
        UpdateBar();
    }

    public void UpdateBar()
    {
        levelBar.maxValue = TotalDistance();
        levelBar.value = GetDistance();
    }

    public float GetDistance()
    {
        return Vector3.Distance(player.position, finishPoint.position);
    }

    public float TotalDistance()
    {
        return Vector3.Distance(startPoint.position, finishPoint.position);
    }
}
