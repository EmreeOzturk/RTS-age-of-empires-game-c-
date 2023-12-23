using UnityEngine;

public class Building : MonoBehaviour
{

    public GameObject spawnUnit;
    public GameObject archer;
    public GameObject soldier;
    public GameObject collector;
    public Vector3 spawnPoint;


    float spawnTime;
    float spawnTimer;

    public float requiredConstructionTime;
    public float constructionTime;
    public bool isConstructing;



    public enum BuildingType
    {
        House,
        Barracks,
        ResourceCollector,
        Constructive

    }

    public BuildingType buildingType;

    public void StartConstruction()
    {
        isConstructing = true;
        constructionTime = 0;
    }

    public void StopConstruction()
    {
        isConstructing = false;
        constructionTime = requiredConstructionTime;
    }

    public void SpeedUpConstruction(float speedUpAmount)
    {
        constructionTime += speedUpAmount;
        if (constructionTime >= requiredConstructionTime)
        {
            constructionTime = requiredConstructionTime;
            isConstructing = false;
        }
    }




    void Start()
    {

        BuildingSelection.Instance.allBuildingsInGame.Add(this.gameObject);

        if (buildingType == BuildingType.House)
        {
            // spawnUnit = Resources.Load("Prefabs/Units/Collector") as Prefa;
            spawnTime = 3;
            spawnTimer = spawnTime;
            spawnPoint = this.transform.position + new Vector3(0, 0, 5);

        }
        else if (buildingType == BuildingType.Barracks)
        {
            // spawnUnit = Resources.Load("Prefabs/Units/Soldier") as GameObject;
            spawnTime = 5;
            spawnTimer = spawnTime;
            spawnPoint = this.transform.position + new Vector3(0, 0, 5);

        }
        else if (buildingType == BuildingType.ResourceCollector)
        {

            spawnUnit = null;
        }

    }
    void Update()
    {

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
