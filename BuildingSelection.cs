using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSelection : MonoBehaviour
{
    public List<GameObject> allBuildingsInGame = new();
    public List<GameObject> selectedBuildings = new();
    private static BuildingSelection _instance; // create a variable that will store the instance of this object
    public static BuildingSelection Instance { get { return _instance; } }

    public GameObject game;

    private void Awake()
    {
        // if there is already an instance of this object 
        if (_instance != null && _instance != this)
        {
            // destroy this object
            Destroy(this.gameObject);
        }
        else
        {
            // set the instance to this object
            _instance = this;
        }
    }

    public void DeselectAll()
    {
        selectedBuildings.Clear();
        foreach (GameObject child in allBuildingsInGame)
        {
            child.transform.GetChild(0).gameObject.SetActive(false);
            if (child.GetComponent<Building>().buildingType == Building.BuildingType.House)
            {
                game.GetComponent<Game>().housePanel.SetActive(false);
            }
            else if (child.GetComponent<Building>().buildingType == Building.BuildingType.Barracks)
            {
                game.GetComponent<Game>().barracksPanel.SetActive(false);
            }
            else if (child.GetComponent<Building>().buildingType == Building.BuildingType.ResourceCollector)
            {
                // game.GetComponent<Game>().resourceCollectorPanel.SetActive(false);
            }
        }
    }
    public void ClickSelect(GameObject buildingToAdd)
    {
        DeselectAll();
        if (!selectedBuildings.Contains(buildingToAdd))
        {
            selectedBuildings.Add(buildingToAdd);
            foreach (GameObject child in selectedBuildings)
            {
                Debug.Log("Selected building: " + child);
                child.transform.GetChild(0).gameObject.SetActive(true);
                if (child.GetComponent<Building>().buildingType == Building.BuildingType.House)
                {
                    game.GetComponent<Game>().housePanel.SetActive(true);
                }
                else if (child.GetComponent<Building>().buildingType == Building.BuildingType.Barracks)
                {
                    game.GetComponent<Game>().barracksPanel.SetActive(true);
                }
                else if (child.GetComponent<Building>().buildingType == Building.BuildingType.ResourceCollector)
                {
                    // game.GetComponent<Game>().resourceCollectorPanel.SetActive(true);
                }
            }
        }
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit; // create a variable that will store the raycast hit information
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Building")))
            {
                BuildingSelection.Instance.ClickSelect(hit.collider.gameObject);
            }
            else
            {
                BuildingSelection.Instance.DeselectAll();
            }
        }
    }
}
