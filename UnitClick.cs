using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitClick : MonoBehaviour
{
    Game game;

    void Start()
    {
        game = GameObject.Find("_Game").GetComponent<Game>();
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
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Unit")))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelection.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    Debug.Log("clicked on unit");
                    Uunit unitObject = hit.collider.gameObject.GetComponentInParent<Uunit>();
                    UnitSelection.Instance.ClickSelect(hit.collider.gameObject);
                    game.unitPanel.SetActive(true);
                    game.unitHealthText.text = unitObject.health.ToString() + "/" + unitObject.maxHealth.ToString();
                    game.unitAttackText.text = unitObject.attack.ToString();
                    game.unitDefenceText.text = unitObject.defence.ToString();
                    game.unitSpellText.text = unitObject.spell.ToString() + "/" + unitObject.maxSpell.ToString();
                    game.image.sprite = unitObject.icon;
                    game.unitNameText.text = unitObject.unitName;
                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelection.Instance.DeselectAll();
                    game.unitPanel.SetActive(false);
                }
            }
        }
    }
}
