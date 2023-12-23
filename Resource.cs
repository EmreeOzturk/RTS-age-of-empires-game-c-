using System.Collections;
using System.Collections.Generic;
using RTS.Game.Units;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public float resourceAmount;
    public float resourceCollectTime;
    public float resourceCollectTimeLeft = 0.0f;
    public bool isSelected = false;
    public int maxCollectors;
    public int currentCollectors;

    public enum ResourceType
    {
        Wood,
        Stone,
        Gold
    }

    public ResourceType resourceType;




    void OnGUI()
    {
        if (isSelected)
        {
            GUI.Label(new Rect(0, 0, 100, 20), "Resource amount: " + resourceAmount);
        }
    }



    void Start()
    {
        resourceAmount = Random.Range(500, 800);
        resourceCollectTime = 0.5f;
        resourceCollectTimeLeft = resourceCollectTime;
        maxCollectors = 5;
        currentCollectors = 0;
    }

    void Update()
    {
        if (resourceAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public bool Collect(Uunit unit)
    {
        Debug.Log("Collecting1111111");
        Debug.Log(resourceAmount);
        if (currentCollectors < maxCollectors)
        {
            unit.targetDestination = this.gameObject;
            unit.resource = this;
            switch (resourceType)
            {
                case ResourceType.Wood:
                    unit.collectingType = Uunit.CollectingType.Wood;
                    break;
                case ResourceType.Stone:
                    unit.collectingType = Uunit.CollectingType.Stone;
                    break;
                case ResourceType.Gold:
                    unit.collectingType = Uunit.CollectingType.Gold;
                    break;
            }
            Debug.Log("Collecting type: " + unit.collectingType);
            return true;
        }
        else
        {
            return false;
        }
    }


}
