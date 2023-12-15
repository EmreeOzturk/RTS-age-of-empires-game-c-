using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject spawnUnit;
    Vector3 spawnPoint;
    float spawnTime;
    float spawnTimer;
    bool isSpawning;


    void Start()
    {
        BuildingSelection.Instance.allBuildingsInGame.Add(this.gameObject);
        spawnPoint = this.transform.position + new Vector3(0, 0, 5);
        spawnTime = 3;
        spawnTimer = spawnTime;
    }
    void Update()
    {
        if (isSpawning && spawnUnit != null)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                GameObject unit = Instantiate(spawnUnit, spawnPoint, Quaternion.identity);
                unit.GetComponent<Uunit>().SetNavMesh();
                unit.GetComponent<Uunit>().MoveUnit(spawnPoint + new Vector3(0, 0, 0.1f));
                spawnTimer = spawnTime;
                spawnPoint += new Vector3(0, 0, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            isSpawning = !isSpawning;
            spawnPoint = this.transform.position + new Vector3(0, 0, 5);
        }

    }
    void OnDestroy()
    {
        BuildingSelection.Instance.allBuildingsInGame.Remove(this.gameObject);
    }

}
