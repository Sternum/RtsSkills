using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AbilitySystem;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

namespace Units
{
    public class AbilityComponent : MonoBehaviour
    {
        private Ability[] abilities;
        public Ability[] Abilities => abilities;

        public void InitializeAbilities(Ability[] abilities)
        {
            this.abilities = abilities;
        }
    }
}