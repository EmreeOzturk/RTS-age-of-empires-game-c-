using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    public Material normalMaterial;
    public Material choosenMaterial;
    public GameObject oldObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Building", "Unit")))
            {
                if (hit.transform.gameObject.TryGetComponent<MeshRenderer>(out var obj) && obj.material != choosenMaterial)
                {
                    if (oldObject != null)
                    {
                        oldObject.GetComponent<MeshRenderer>().material = normalMaterial;
                    }
                    obj.material = choosenMaterial;
                    oldObject = hit.transform.gameObject;
                }
                Debug.Log(hit.transform.gameObject.name);
            }
            else
            {
                if (oldObject != null)
                {
                    oldObject.GetComponent<MeshRenderer>().material = normalMaterial;
                    oldObject = null;
                }
            }
        }
    }
}
