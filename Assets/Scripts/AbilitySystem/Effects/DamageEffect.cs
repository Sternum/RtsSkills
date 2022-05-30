using Units;
using UnityEngine;

namespace AbilitySystem.Effects
{
    [CreateAssetMenu(fileName = "Heal Effect", menuName = "Abilities/Effects/Damage", order = 0)]
    public class DamageEffect : EffectStrategy
    {
        public override void StartEffect(AbilityData abilityData)
        {
            foreach (GameObject target in abilityData.Targets)
            {
                UnitStatsComponent unitStatsComponent = abilityData.User.GetComponent<UnitStatsComponent>();
                UnitStats unitStats = unitStatsComponent.GetStats();
                HealthComponent healthComponent = target.GetComponent<HealthComponent>();
                if (healthComponent != null)
                {
                    healthComponent.ApplyDamage(unitStats.Damage);
                }
            }
        }
    }
}