using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int resourceAmount = 100;
    public int resourceCollectAmount = 10;
    public float resourceCollectTime = 0.5f;
    public float resourceCollectTimeLeft = 0.0f;
    public bool isSelected = false;
    public int type = 0; // 0 = wood, 1 = stone, 2 = gold

    public void StartCollecting()
    {
        StartCoroutine(CollectResourceCoroutine());
    }

    IEnumerator CollectResourceCoroutine()
    {
        while (isSelected)
        {
            CollectResource();
            yield return new WaitForSeconds(1);
        }
    }



    public void CollectResource()
    {
        resourceCollectTimeLeft -= Time.deltaTime;
        if (resourceCollectTimeLeft <= 0.0f)
        {
            resourceCollectTimeLeft = resourceCollectTime;
            resourceAmount -= resourceCollectAmount;
            Debug.Log("Resource amount left: " + resourceAmount);
        }
    }

    void OnGUI()
    {
        if (isSelected)
        {
            GUI.Label(new Rect(0, 0, 100, 20), "Resource amount: " + resourceAmount);
        }
    }



    void Start()
    {

    }

    void Update()
    {
        if (resourceAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
