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

    Game game;
    GameObject canvas;

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(1);
        canvas.SetActive(false);
    }
    public void BuildBarracks()
    {
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
            canvas.SetActive(true);
            StartCoroutine(HideMessage());

        }
    }

    public void BuildSmith()
    {
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
            canvas.SetActive(true);
            StartCoroutine(HideMessage());

        }
    }



    public void BuildHouse()
    {
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
            canvas.SetActive(true);
            StartCoroutine(HideMessage());
        }
    }

    public void BuildSawMill()
    {
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
            canvas.SetActive(true);
            StartCoroutine(HideMessage());
        }
    }

    public void BuildMine()
    {
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
            canvas.SetActive(true);
            StartCoroutine(HideMessage());
        }
    }

    public void BuildQuarry()
    {
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
            canvas.SetActive(true);
            StartCoroutine(HideMessage());
        }
    }


    void Start()
    {
        game = GameObject.Find("_Game").GetComponent<Game>();
        canvas = game.NotEnoughResourcesPanel;
    }

    void Update()
    { }


}
