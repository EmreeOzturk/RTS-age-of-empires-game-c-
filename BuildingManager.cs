using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    private BuildingPlacement buildingPlacement;

    void Start()
    {
        buildingPlacement = GetComponent<BuildingPlacement>();
    }

    void Update()
    {

    }
    void OnGUI()
    {
        for (int i = 0; i < buildingPrefabs.Length; i++)
        {
            if (GUI.Button(new Rect(0, 0 + (i * 25), 100, 20), buildingPrefabs[i].name))
            {
                buildingPlacement.SetItem(buildingPrefabs[i]);
            }
        }
    }
}
