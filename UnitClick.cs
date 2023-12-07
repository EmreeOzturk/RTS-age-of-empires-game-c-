using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    void Update()
    {
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
                    UnitSelection.Instance.ClickSelect(hit.collider.gameObject);
                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelection.Instance.DeselectAll();
                }
            }
        }
    }
}
