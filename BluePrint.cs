using UnityEngine;

public class BluePrint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 mousePos;

    Vector3 buildingPos;
    public GameObject prefab;

    UnitSelection unitSelection;

    GameObject unit;

    bool isClickedOnce;


    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50000f))
        {
            mousePos = hit.point;
            mousePos.y = 0;
            transform.position = mousePos;
        }

        unitSelection = GameObject.Find("_UnitSelectionSystem").GetComponentInChildren<UnitSelection>();
        unit = unitSelection.selectedUnits[0].GetComponentInParent<Uunit>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            mousePos = hit.point;
            mousePos.y = 0;
            transform.position = mousePos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!isClickedOnce)
            {
                isClickedOnce = true;
                if (unit.GetComponent<Uunit>().unitState != Uunit.UnitState.GoingToBuilding)
                {
                    Debug.Log("not going to building");
                    unit.GetComponent<Uunit>().MoveToBuilding(transform.position);
                }
                // gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
                GameObject go = gameObject.transform.GetChild(0).gameObject;
                go.SetActive(false);
                GameObject go2 = gameObject.transform.GetChild(1).gameObject;
                go2.SetActive(false);
                buildingPos = transform.position + new Vector3(0, 0, 5);
            }
        }

        if (unit.GetComponent<Uunit>().unitState == Uunit.UnitState.Building)
        {
            Debug.Log("Building");
            if (unit.GetComponent<Uunit>().unitType == Uunit.UnitType.Collector)
            {
                Instantiate(prefab, buildingPos, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
