using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS.Game.Units
{
    [CreateAssetMenu(fileName = "New Unit", menuName = "Create New Unit")]
    public class Unit : ScriptableObject
    {
        public enum unitType
        {
            Worker,
            Warrior,
            Healer
        }
        public bool isPlayerUnit;
        public unitType type;
        public new string name;
        public GameObject unitPrefab;
        public int cost;
        public int health;
        public int attack;
        public int armor;

    }
}

