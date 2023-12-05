using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS.Game.Units
{
    public class NewBehaviourScript : MonoBehaviour
    {
        public Unit _unit;
        public Transform workers;
        void Start()
        {
            GameObject unitObject = Instantiate(_unit.unitPrefab, transform.position, Quaternion.identity, workers);
        }
    }
}

