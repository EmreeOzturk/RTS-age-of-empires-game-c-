using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public GameObject spawnUnit;
    public Vector3 spawnPoint;


    float spawnTime;
    float spawnTimer;
    bool isSpawning;


    public enum BuildingType
    {
        House,
        Barracks,
        ResourceCollector
    }

    public BuildingType buildingType;


    void Start()
    {

        BuildingSelection.Instance.allBuildingsInGame.Add(this.gameObject);
        if (buildingType == BuildingType.House)
        {
            isSpawning = false;
            // spawnUnit = Resources.Load("Prefabs/Units/Collector") as Prefa;
            spawnTime = 3;
            spawnTimer = spawnTime;
            spawnPoint = this.transform.position + new Vector3(0, 0, 5);

        }
        else if (buildingType == BuildingType.Barracks)
        {
            isSpawning = false;
            // spawnUnit = Resources.Load("Prefabs/Units/Soldier") as GameObject;
            spawnTime = 5;
            spawnTimer = spawnTime;
            spawnPoint = this.transform.position + new Vector3(0, 0, 5);

        }
        else if (buildingType == BuildingType.ResourceCollector)
        {
            
            isSpawning = false;
            spawnUnit = null;
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && (buildingType == BuildingType.House || buildingType == BuildingType.Barracks))
        {
            isSpawning = !isSpawning;
            spawnPoint = this.transform.position + new Vector3(0, 0, 5);
        }

        if (isSpawning && (buildingType == BuildingType.House || buildingType == BuildingType.Barracks))
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                SpawnUnit();
            }
        }



    }

    public void SpawnUnit()
    {
        GameObject unit = Instantiate(spawnUnit, spawnPoint, Quaternion.identity);
        unit.GetComponent<Uunit>().SetNavMesh();
        unit.GetComponent<Uunit>().MoveUnit(spawnPoint + new Vector3(0, 0, 0.1f));
        spawnTimer = spawnTime;
        spawnPoint += new Vector3(0, 0, 1);
    }
    void OnDestroy()
    {
        BuildingSelection.Instance.allBuildingsInGame.Remove(this.gameObject);
    }

}
