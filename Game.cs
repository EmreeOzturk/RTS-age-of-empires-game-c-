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
    public GameObject constructivePanel;

    public BuildingSelection buildingSelection;

    public GameObject NotEnoughResourcesPanel;
    public GameObject SoldierCannotBuildPanel;
    public GameObject swordResearchNeededPanel;
    public GameObject arrowResearchNeededPanel;

    public GameObject researchSuccessPanel;
    public TextMeshProUGUI unitHealthText;
    public TextMeshProUGUI unitAttackText;
    public TextMeshProUGUI unitDefenceText;
    public TextMeshProUGUI unitSpellText;
    public TextMeshProUGUI unitNameText;
    public Image image;

    public int wood;
    public int stone;
    public int gold;


    bool isSwordResearched;
    bool isArrowResearched;
    public GameObject collector;
    public GameObject soldier;

    void Start()
    {
        stoneText.text = stone.ToString();
        goldText.text = gold.ToString();
        woodText.text = wood.ToString();

        isSwordResearched = false;
        isArrowResearched = false;
    }

    IEnumerator HideMessage(string type)
    {
        yield return new WaitForSeconds(1);
        if (type == "notEnoughResources")
        {
            NotEnoughResourcesPanel.SetActive(false);
        }
        else if (type == "researchSuccess")
        {
            researchSuccessPanel.SetActive(false);
        }
        else if (type == "swordResearchNeeded")
        {
            swordResearchNeededPanel.SetActive(false);
        }
        else if (type == "arrowResearchNeeded")
        {
            arrowResearchNeededPanel.SetActive(false);
        }

    }

    public void researchSword()
    {
        if (isSwordResearched == false)
        {
            if (gold >= 30 && wood >= 30 && stone >= 30)
            {
                gold -= 30;
                wood -= 30;
                stone -= 30;

                stoneText.text = stone.ToString();
                goldText.text = gold.ToString();
                woodText.text = wood.ToString();
                isSwordResearched = true;

                researchSuccessPanel.SetActive(true);
                StartCoroutine(HideMessage("researchSuccess"));
            }
            else
            {
                NotEnoughResourcesPanel.SetActive(true);
                StartCoroutine(HideMessage("notEnoughResources"));
            }
        }
    }

    public void researchArrow()
    {
        if (isArrowResearched == false)
        {
            if (gold >= 30 && wood >= 30 && stone >= 30)
            {
                gold -= 30;
                wood -= 30;
                stone -= 30;

                stoneText.text = stone.ToString();
                goldText.text = gold.ToString();
                woodText.text = wood.ToString();
                isArrowResearched = true;

                researchSuccessPanel.SetActive(true);
                StartCoroutine(HideMessage("researchSuccess"));
            }
            else
            {
                NotEnoughResourcesPanel.SetActive(true);
                StartCoroutine(HideMessage("notEnoughResources"));
            }
        }
    }

    public void SpawnArcher()
    {
        GameObject building = BuildingSelection.Instance.selectedBuildings[0];
        if (building.GetComponent<Building>().buildingType == Building.BuildingType.Barracks)
        {
            if (isArrowResearched == false)
            {
                arrowResearchNeededPanel.SetActive(true);
                StartCoroutine(HideMessage("arrowResearchNeeded"));
                return;
            }
            if (wood >= 10 && stone >= 10 && gold >= 10)
            {
                wood -= 10;
                stone -= 10;
                gold -= 10;
                stoneText.text = stone.ToString();
                goldText.text = gold.ToString();
                woodText.text = wood.ToString();
                GameObject unit = Instantiate(building.GetComponent<Building>().archer, building.GetComponent<Building>().spawnPoint, Quaternion.identity);
                unit.GetComponent<Uunit>().SetNavMesh();
                unit.GetComponent<Uunit>().MoveUnit(building.GetComponent<Building>().spawnPoint + new Vector3(0, 0, 0.1f));
                building.GetComponent<Building>().spawnPoint += new Vector3(0, 0, 1);
            }
            else
            {
                NotEnoughResourcesPanel.SetActive(true);
                StartCoroutine(HideMessage("notEnoughResources"));
            }
        }
    }

    public void SpawnUnit()
    {
        GameObject building = BuildingSelection.Instance.selectedBuildings[0];
        if (building.GetComponent<Building>().buildingType == Building.BuildingType.Barracks)
        {
            if (isSwordResearched == false)
            {
                swordResearchNeededPanel.SetActive(true);
                StartCoroutine(HideMessage("swordResearchNeeded"));
                return;
            }
            if (wood >= 10 && stone >= 10 && gold >= 10)
            {
                wood -= 10;
                stone -= 10;
                gold -= 10;
                stoneText.text = stone.ToString();
                goldText.text = gold.ToString();
                woodText.text = wood.ToString();
                GameObject unit = Instantiate(building.GetComponent<Building>().soldier, building.GetComponent<Building>().spawnPoint, Quaternion.identity);
                unit.GetComponent<Uunit>().SetNavMesh();
                unit.GetComponent<Uunit>().MoveUnit(building.GetComponent<Building>().spawnPoint + new Vector3(0, 0, 0.1f));
                building.GetComponent<Building>().spawnPoint += new Vector3(0, 0, 1);
            }
            else
            {
                NotEnoughResourcesPanel.SetActive(true);
                StartCoroutine(HideMessage("notEnoughResources"));
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
                GameObject unit = Instantiate(building.GetComponent<Building>().collector, building.GetComponent<Building>().spawnPoint, Quaternion.identity);
                unit.GetComponent<Uunit>().SetNavMesh();
                unit.GetComponent<Uunit>().MoveUnit(building.GetComponent<Building>().spawnPoint + new Vector3(0, 0, 0.1f));
                building.GetComponent<Building>().spawnPoint += new Vector3(0, 0, 1);
            }
            else
            {
                NotEnoughResourcesPanel.SetActive(true);
                StartCoroutine(HideMessage("notEnoughResources"));
            }
        }
    }
}
