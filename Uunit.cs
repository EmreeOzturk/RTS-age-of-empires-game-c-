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

    public enum UnitState
    {
        Idle,
        MovingToResource,
        MovingToBuilding,
        Moving,
        Collecting,
        Attacking
    }

    public UnitType unitType;
    public UnitState unitState;
    public GameObject targetDestination;
    public GameObject resourceCollectorBuildingDestination;
    public enum CollectingType { Wood, Stone, Gold }
    public CollectingType collectingType;
    public bool isCollector;
    public bool isCollectingNow;
    public float resourceCapacity;
    public Resource resource;
    float receivedResources;
    Game game;
    public BuildingSelection buildingSelection;
    NavMeshAgent agent; // the NavMeshAgent component of the unit
    // Start is called before the first frame update
    void Start()
    {
        if (unitType == UnitType.Collector)
        {
            isCollector = true;
            isCollectingNow = false;
            resourceCapacity = 10;
            receivedResources = 0;
            game = GameObject.Find("_Game").GetComponent<Game>();

        }
        else if (unitType == UnitType.Soldier)
        {
            isCollector = false;
            isCollectingNow = false;
            resourceCapacity = 0;
            receivedResources = 0;
        }
        unitState = UnitState.Idle;
        agent = GetComponent<NavMeshAgent>();
        UnitSelection.Instance.allUnitsInGame.Add(this.gameObject);
    }

    bool FindClosestCollectorBuilding()
    {
        GameObject closestResource = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject building in BuildingSelection.Instance.allBuildingsInGame)
        {
            if (building.GetComponent<Building>().buildingType == Building.BuildingType.ResourceCollector)
            {
                float distance = Vector3.Distance(this.transform.position, building.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestResource = building;
                }
            }
        }
        if (closestResource != null)
        {
            Debug.Log("Closest resource: " + closestResource);
            resourceCollectorBuildingDestination = closestResource;
            return true;
        }
        else
        {
            Debug.Log("No resource found");
            return false;
        }
    }

    void Update()
    {
        // kaynağa gidiyor
        if (unitState == UnitState.MovingToResource && isCollector)
        {
            // Debug.Log("Girdi1");
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        Debug.Log("Reached destination");
                        unitState = UnitState.Collecting;
                        isCollectingNow = true;
                    }
                }
            }
        }

        // topluyor
        if (isCollectingNow && isCollector && unitState == UnitState.Collecting)
        {
            // Debug.Log("Girdi2");

            if (receivedResources < resourceCapacity)
            {
                resource.resourceAmount -= Time.deltaTime * 2;
                if (resource.resourceAmount <= 0)
                {
                    resource.resourceAmount = 0;
                    isCollectingNow = false;
                    unitState = UnitState.Idle;
                }
                receivedResources += Time.deltaTime * 2;
                // Debug.Log("Received resources: " + receivedResources);
            }
            // hepsini topladı bırakması lazım
            else
            {
                receivedResources = resourceCapacity;
                isCollectingNow = false;
                Debug.Log("Can't collect anymore");
                if (FindClosestCollectorBuilding())
                {
                    Debug.Log("Moving to building");
                    unitState = UnitState.MovingToBuilding;
                    MoveUnit(resourceCollectorBuildingDestination.transform.position);
                }
                else
                {
                    Debug.Log("No building found");
                    unitState = UnitState.Idle;
                }
            }
        }
        if (unitState == UnitState.MovingToBuilding && isCollector)
        {
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        Debug.Log("Reached building");
                        switch (collectingType)
                        {
                            case CollectingType.Wood:
                                game.wood += (int)receivedResources;
                                break;
                            case CollectingType.Stone:
                                game.stone += (int)receivedResources;
                                break;
                            case CollectingType.Gold:
                                game.gold += (int)receivedResources;
                                break;
                        }
                        receivedResources = 0;
                        unitState = UnitState.MovingToResource;
                        MoveUnit(targetDestination.transform.position);
                    }
                }
            }
        }
    }

    void OnDestroy()
    {
        UnitSelection.Instance.allUnitsInGame.Remove(this.gameObject);
    }
    public void MoveUnit(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void SetNavMesh()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    public void GoToResource(Resource r)
    {
        Debug.Log("Going to resource");
        MoveUnit(r.transform.position + new Vector3(0, 0, 0.1f));
        if (isCollector)
        {
            unitState = UnitState.MovingToResource;
            Debug.Log(unitState);
            Debug.Log("Going to asdasdasd");

            if (r.GetComponent<Resource>().Collect(this))
            {
                Debug.Log("Toplamaya basla");
            }
            else
            {
                Debug.Log("Yer Yok");
            }
        }
    }

}
