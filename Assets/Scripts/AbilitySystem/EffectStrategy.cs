using System;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
    public abstract class EffectStrategy : ScriptableObject
    {
        public abstract void StartEffect(AbilityData abilityData);
    }
}