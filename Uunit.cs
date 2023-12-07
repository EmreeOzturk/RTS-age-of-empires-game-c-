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
        UnitSelection.Instance.allUnitsInGame.Add(this.gameObject);
    }
    void OnDestroy()
    {
        UnitSelection.Instance.allUnitsInGame.Remove(this.gameObject);
    }

    // Update is called once per frame
    public void MoveUnit(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

}
