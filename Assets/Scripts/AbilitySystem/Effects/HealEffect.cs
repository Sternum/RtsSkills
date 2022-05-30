using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace AbilitySystem.Effects
{
    [CreateAssetMenu(fileName = "Heal Effect", menuName = "Abilities/Effects/Spells/Heal", order = 0)]
    public class HealEffect : EffectStrategy
    {

        [SerializeField] private int healPower = 0;

        public override void StartEffect(AbilityData abilityData)
        {
            foreach (GameObject target in abilityData.Targets)
            {
                IHealable healthComponent = target.GetComponent<IHealable>();
                healthComponent.ApplyHeal(healPower);
            }
        }
    }
}