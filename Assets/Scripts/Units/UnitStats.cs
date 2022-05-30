using System;
using UnityEngine;

namespace Units
{
    [Serializable]
    public class UnitStats
    {
        private GameObject owner;
        private int luck;
        private int damage;
    
        public UnitStats(GameObject owner)
        {
            this.owner = owner;
        }

        public GameObject Owner
        {
            get => owner;
            set => owner = value;
        }

        public int Luck
        {
            get => luck;
            set => luck = value;
        }

        public int Damage
        {
            get => damage;
            set => damage = value;
        }
    }
}