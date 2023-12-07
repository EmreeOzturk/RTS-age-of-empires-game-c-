using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    public Material normalMaterial;
    public Material choosenMaterial;
    GameObject oldObject;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;           // create a variable that will store the raycast hit information
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray from the camera to the mouse position
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Building", "Unit")))  // if the raycast hits something on the "Building" layer or the "Unit" layer...
            {
                if (hit.transform.gameObject.TryGetComponent<MeshRenderer>(out var obj) && obj.material != choosenMaterial) // if the object has a MeshRenderer component and the object is not already selected...
                {
                    if (oldObject != null)  // if there is an old object selected...
                    {
                        oldObject.GetComponent<MeshRenderer>().material = normalMaterial; // set the old object's material to the normal material
                    }

                    obj.material = choosenMaterial;  // set the new object's material to the choosen material
                    oldObject = hit.transform.gameObject; // set the old object to the new object
                }
            }
            else // if the raycast does not hit anything on the "Building" layer or the "Unit" layer...
            {
                if (oldObject != null)
                {
                    oldObject.GetComponent<MeshRenderer>().material = normalMaterial; // set the old object's material to the normal material
                    oldObject = null; // set the old object to null
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && oldObject != null && oldObject.layer == LayerMask.NameToLayer("Unit")) // if right button pressed and there is an old object selected...
        {
            RaycastHit hit;           // create a variable that will store the raycast hit information
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray from the camera to the mouse position
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Plane")))  // if the raycast hits something on the "Ground" layer...
            {
                oldObject.GetComponentInParent<Uunit>().MoveUnit(hit.point); // move the unit to the hit point
            }
        }
    }
}
