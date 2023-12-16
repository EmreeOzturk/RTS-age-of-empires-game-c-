using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Uunit : MonoBehaviour
{
    public enum UnitType
    {
        Collector,
        Soldier
    }
    public bool isCollector = false;
    public bool canCollect = false;
    public float resourceCapacity;
    public float receivedResources;
    NavMeshAgent agent; // the NavMeshAgent component of the unit
    // Start is called before the first frame update
    void Start()
    {
        if (isCollector)
        {
            resourceCapacity = 10;
            receivedResources = 0;
        }
        agent = GetComponent<NavMeshAgent>();
        UnitSelection.Instance.allUnitsInGame.Add(this.gameObject);
    }

    void Update()
    {
        // if (isCollector)
        // {
        //     if (!agent.pathPending)
        //     {
        //         if (agent.remainingDistance <= agent.stoppingDistance)
        //         {
        //             if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
        //             {
        //                 Debug.Log("Reached destination");
        //                 canCollect = true;
        //             }
        //         }
        //     }
        // }
        // if (canCollect)
        // {
        //     if (receivedResources < resourceCapacity)
        //     {
        //         receivedResources += Time.deltaTime * 2;
        //         Debug.Log("Received resources: " + receivedResources);
        //     }
        //     else
        //     {
        //         receivedResources = resourceCapacity;
        //         canCollect = false;
        //         Debug.Log("Can't collect anymore");
        //     }
        // }

    }
    void OnDestroy()
    {
        UnitSelection.Instance.allUnitsInGame.Remove(this.gameObject);
    }

    // Update is called once per frame
    public void MoveUnit(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void SetNavMesh()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void CollectResource(GameObject resource)
    {
        StartCoroutine(CollectResourceCoroutine(resource));
    }

    IEnumerator CollectResourceCoroutine(GameObject resource)
    {
        while (canCollect)
        {
            resource.GetComponent<Resource>().CollectResource();
            yield return new WaitForSeconds(1);
        }
    }

    public void GoToResource(Resource r)
    {
        Debug.Log("Going to resource");
        MoveUnit(r.transform.position);
        if (isCollector && canCollect)
        {
            Debug.Log("Collecting resource");
            // r.CollectResource();
        }
    }

}
