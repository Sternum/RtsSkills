using System;
using AbilitySystem;
using AbilitySystem.Effects;
using Units.so.Unit;
using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    [RequireComponent(typeof(AbilityComponent), typeof(NavMeshAgent), typeof(HealthComponent))]
    [RequireComponent(typeof(StatusEffectComponent), typeof(UnitStatsComponent))]
    public class UnitComponent : MonoBehaviour
    {
        public UnitData unitData;

        private void Awake()
        {
            GetComponent<HealthComponent>().InitialiazeHealth(unitData.UnitMaxHealth);
            GetComponent<UnitStatsComponent>().InitializeStats(unitData.UnitStats);
            GetComponent<AbilityComponent>().InitializeAbilities(unitData.UnitAbilties);
        }
    }
}