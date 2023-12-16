using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{

    public List<GameObject> allUnitsInGame = new();
    public List<GameObject> selectedUnits = new();
    private static UnitSelection _instance; // create a variable that will store the instance of this object
    public static UnitSelection Instance { get { return _instance; } }

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

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        if (!selectedUnits.Contains(unitToAdd))
        {
            selectedUnits.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!selectedUnits.Contains(unitToAdd))
        {
            selectedUnits.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            selectedUnits.Remove(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void DragSelect(GameObject unitToAdd)
    {
        if (!selectedUnits.Contains(unitToAdd))
        {
            selectedUnits.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
    }
    public void DeselectAll()
    {
        selectedUnits.Clear();
        foreach (GameObject unit in allUnitsInGame)
        {
            unit.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
    }
    public void Deselect(GameObject unitToRemove)
    {
        selectedUnits.Remove(unitToRemove);
        unitToRemove.transform.GetChild(0).gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;           // create a variable that will store the raycast hit information
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray from the camera to the mouse position
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Plane")))  // if the raycast hits something on the "Ground" layer...
            {
                foreach (GameObject unit in selectedUnits)
                {
                    if (!unit.TryGetComponent<Uunit>(out Uunit unitScript))
                    {
                        unit.GetComponentInParent<Uunit>().MoveUnit(hit.point);
                    }
                    else
                    {
                        unitScript.MoveUnit(hit.point);
                    }
                }
            }

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Resource")))  // if the raycast hits something on the "Ground" layer...
            {
                foreach (GameObject unit in selectedUnits)
                {
                    if (!unit.TryGetComponent<Uunit>(out Uunit unitScript))
                    {
                        unit.GetComponentInParent<Uunit>().MoveUnit(hit.point);
                    }
                    else
                    {
                        unitScript.MoveUnit(hit.point);
                    }
                }
            }
        }
    }
}
