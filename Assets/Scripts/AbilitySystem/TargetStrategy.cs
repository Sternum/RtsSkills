using System;
using UnityEngine;

namespace AbilitySystem
{
    public abstract class TargetStrategy : ScriptableObject
    {
        public abstract void StartTargeting(AbilityData abilityData, Action callback);
    }
}