using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFloorCheck : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = this.gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetComponent<EnemyScript>().dead == true)
        {
            boxCollider.isTrigger = true;
        }
    }
}
