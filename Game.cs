using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("Resources")]
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI woodText;

    [Header("Unit Panel")]
    public GameObject unitPanel;
    public GameObject housePanel;
    public GameObject barracksPanel;

    public BuildingSelection buildingSelection;

    public GameObject NotEnoughResourcesPanel;
    public TextMeshProUGUI unitHealthText;
    public TextMeshProUGUI unitAttackText;
    public TextMeshProUGUI unitDefenceText;
    public TextMeshProUGUI unitSpellText;
    public TextMeshProUGUI unitNameText;
    public Image image;

    public int wood;
    public int stone;
    public int gold;

    public GameObject collector;
    public GameObject soldier;

    void Start()
    {
        stoneText.text = stone.ToString();
        goldText.text = gold.ToString();
        woodText.text = wood.ToString();
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(1);
        NotEnoughResourcesPanel.SetActive(false);
    }

    public void SpawnUnit()
    {
        GameObject building = BuildingSelection.Instance.selectedBuildings[0];
        if (building.GetComponent<Building>().buildingType == Building.BuildingType.Barracks)
        {
            if (wood >= 10 && stone >= 10 && gold >= 10)
            {
                wood -= 10;
                stone -= 10;
                gold -= 10;
                stoneText.text = stone.ToString();
                goldText.text = gold.ToString();
                woodText.text = wood.ToString();
                GameObject unit = Instantiate(building.GetComponent<Building>().spawnUnit, building.GetComponent<Building>().spawnPoint, Quaternion.identity);
                unit.GetComponent<Uunit>().SetNavMesh();
                unit.GetComponent<Uunit>().MoveUnit(building.GetComponent<Building>().spawnPoint + new Vector3(0, 0, 0.1f));
                building.GetComponent<Building>().spawnPoint += new Vector3(0, 0, 1);


            }
            else
            {
                NotEnoughResourcesPanel.SetActive(true);
                StartCoroutine(HideMessage());
            }
        }
        else if (building.GetComponent<Building>().buildingType == Building.BuildingType.House)
        {
            if (wood >= 10 && stone >= 10 && gold >= 10)
            {
                wood -= 10;
                stone -= 10;
                gold -= 10;
                stoneText.text = stone.ToString();
                goldText.text = gold.ToString();
                woodText.text = wood.ToString();
                GameObject unit = Instantiate(building.GetComponent<Building>().spawnUnit, building.GetComponent<Building>().spawnPoint, Quaternion.identity);
                unit.GetComponent<Uunit>().SetNavMesh();
                unit.GetComponent<Uunit>().MoveUnit(building.GetComponent<Building>().spawnPoint + new Vector3(0, 0, 0.1f));
                building.GetComponent<Building>().spawnPoint += new Vector3(0, 0, 1);
            }
            else
            {
                NotEnoughResourcesPanel.SetActive(true);
                StartCoroutine(HideMessage());
            }
        }
    }
}
