using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCanvas : MonoBehaviour
{
    public GameObject barrackBluePrint;
    public GameObject houseBluePrint;
    public GameObject sawMillBluePrint;
    public GameObject mineBluePrint;
    public GameObject quarryBluePrint;

    public GameObject smithBluePrint;
    GameObject unit;
    Game game;
    GameObject notEnoughResourcesPanel;
    GameObject soldierCannotBuildPanel;

    UnitSelection unitSelection;
    IEnumerator HideMessage(string type)
    {
        yield return new WaitForSeconds(1);
        if (type == "notEnoughResources")
        {
            notEnoughResourcesPanel.SetActive(false);
        }
        else if (type == "soldierCannotBuild")
        {
            soldierCannotBuildPanel.SetActive(false);
        }
    }
    public void BuildBarracks()
    {
        unitSelection = GameObject.Find("_UnitSelectionSystem").GetComponentInChildren<UnitSelection>();
        unit = unitSelection.selectedUnits[0].GetComponentInParent<Uunit>().gameObject;
        if (unit.GetComponent<Uunit>().unitType != Uunit.UnitType.Collector)
        {
            soldierCannotBuildPanel.SetActive(true);
            StartCoroutine(HideMessage("soldierCannotBuild"));

            return;
        }
        if (game.gold >= 30 && game.wood >= 30 && game.stone >= 30)
        {
            game.gold -= 30;
            game.wood -= 30;
            game.stone -= 30;
            game.stoneText.text = game.stone.ToString();
            game.goldText.text = game.gold.ToString();
            game.woodText.text = game.wood.ToString();
            Instantiate(barrackBluePrint);
        }
        else
        {
            notEnoughResourcesPanel.SetActive(true);
            StartCoroutine(HideMessage("notEnoughResources"));

        }
    }

    public void BuildSmith()
    {
        unitSelection = GameObject.Find("_UnitSelectionSystem").GetComponentInChildren<UnitSelection>();
        unit = unitSelection.selectedUnits[0].GetComponentInParent<Uunit>().gameObject;
        if (unit.GetComponent<Uunit>().unitType != Uunit.UnitType.Collector)
        {
            soldierCannotBuildPanel.SetActive(true);
            StartCoroutine(HideMessage("soldierCannotBuild"));

            return;
        }
        if (game.gold >= 30 && game.wood >= 30 && game.stone >= 30)
        {
            game.gold -= 30;
            game.wood -= 30;
            game.stone -= 30;
            game.stoneText.text = game.stone.ToString();
            game.goldText.text = game.gold.ToString();
            game.woodText.text = game.wood.ToString();
            Instantiate(smithBluePrint);
        }
        else
        {
            notEnoughResourcesPanel.SetActive(true);
            StartCoroutine(HideMessage("notEnoughResources"));

        }
    }



    public void BuildHouse()
    {
        unitSelection = GameObject.Find("_UnitSelectionSystem").GetComponentInChildren<UnitSelection>();
        unit = unitSelection.selectedUnits[0].GetComponentInParent<Uunit>().gameObject;
        if (unit.GetComponent<Uunit>().unitType != Uunit.UnitType.Collector)
        {
            soldierCannotBuildPanel.SetActive(true);
            StartCoroutine(HideMessage("soldierCannotBuild"));

            return;
        }
        if (game.gold >= 30 && game.wood >= 30 && game.stone >= 30)
        {
            game.gold -= 30;
            game.wood -= 30;
            game.stone -= 30;
            game.stoneText.text = game.stone.ToString();
            game.goldText.text = game.gold.ToString();
            game.woodText.text = game.wood.ToString();
            Instantiate(houseBluePrint);
        }
        else
        {
            notEnoughResourcesPanel.SetActive(true);
            StartCoroutine(HideMessage("notEnoughResources"));
        }
    }

    public void BuildSawMill()
    {
        unitSelection = GameObject.Find("_UnitSelectionSystem").GetComponentInChildren<UnitSelection>();
        unit = unitSelection.selectedUnits[0].GetComponentInParent<Uunit>().gameObject;
        if (unit.GetComponent<Uunit>().unitType != Uunit.UnitType.Collector)
        {
            soldierCannotBuildPanel.SetActive(true);
            StartCoroutine(HideMessage("soldierCannotBuild"));

            return;
        }
        if (game.gold >= 30 && game.wood >= 30 && game.stone >= 30)
        {
            game.gold -= 30;
            game.wood -= 30;
            game.stone -= 30;
            game.stoneText.text = game.stone.ToString();
            game.goldText.text = game.gold.ToString();
            game.woodText.text = game.wood.ToString();
            Instantiate(sawMillBluePrint);
        }
        else
        {
            notEnoughResourcesPanel.SetActive(true);
            StartCoroutine(HideMessage("notEnoughResources"));
        }
    }

    public void BuildMine()
    {
        unitSelection = GameObject.Find("_UnitSelectionSystem").GetComponentInChildren<UnitSelection>();
        unit = unitSelection.selectedUnits[0].GetComponentInParent<Uunit>().gameObject;
        if (unit.GetComponent<Uunit>().unitType != Uunit.UnitType.Collector)
        {
            soldierCannotBuildPanel.SetActive(true);
            StartCoroutine(HideMessage("soldierCannotBuild"));

            return;
        }
        if (game.gold >= 30 && game.wood >= 30 && game.stone >= 30)
        {
            game.gold -= 30;
            game.wood -= 30;
            game.stone -= 30;
            game.stoneText.text = game.stone.ToString();
            game.goldText.text = game.gold.ToString();
            game.woodText.text = game.wood.ToString();
            Instantiate(mineBluePrint);
        }
        else
        {
            notEnoughResourcesPanel.SetActive(true);
            StartCoroutine(HideMessage("notEnoughResources"));
        }
    }

    public void BuildQuarry()
    {

        unitSelection = GameObject.Find("_UnitSelectionSystem").GetComponentInChildren<UnitSelection>();
        unit = unitSelection.selectedUnits[0].GetComponentInParent<Uunit>().gameObject;
        if (unit.GetComponent<Uunit>().unitType != Uunit.UnitType.Collector)
        {
            soldierCannotBuildPanel.SetActive(true);
            StartCoroutine(HideMessage("soldierCannotBuild"));

            return;
        }
        if (game.gold >= 30 && game.wood >= 30 && game.stone >= 30)
        {
            game.gold -= 30;
            game.wood -= 30;
            game.stone -= 30;
            game.stoneText.text = game.stone.ToString();
            game.goldText.text = game.gold.ToString();
            game.woodText.text = game.wood.ToString();
            Instantiate(quarryBluePrint);
        }
        else
        {
            notEnoughResourcesPanel.SetActive(true);
            StartCoroutine(HideMessage("notEnoughResources"));
        }
    }


    void Start()
    {
        game = GameObject.Find("_Game").GetComponent<Game>();
        notEnoughResourcesPanel = game.NotEnoughResourcesPanel;
        soldierCannotBuildPanel = game.SoldierCannotBuildPanel;
    }

    void Update()
    { }


}
