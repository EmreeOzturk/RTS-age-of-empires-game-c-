using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Uunit : MonoBehaviour
{
    NavMeshAgent agent; // the NavMeshAgent component of the unit
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveUnit(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

}
